using System;
using System.Collections.Generic;
using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.CustomLog;
using BackupsExtra.Exceptions;
using BackupsExtra.Repository;
namespace BackupsExtra.Backup
{
    public class RestorePointsController
    {
        private ICleanerStrategy _cleanerStrategy;
        private List<RestorePoint> _pointsToClean;
        private Logger _logger;
        private IExtraRepository _repository;
        public RestorePointsController()
        {
        }

        public void SetLogger(Logger logger)
        {
            _logger = logger;
        }

        public void SetRepository(IExtraRepository repository)
        {
            _repository = repository;
        }

        public void SetStrategy(ICleanerStrategy strategy)
        {
            _cleanerStrategy = strategy;
        }

        public List<RestorePoint> GetPointsToClean(List<RestorePoint> points)
        {
            List<RestorePoint> result = _cleanerStrategy.FindPointsToClean(points);
            if (result.Count >= points.Count) throw new AllPointsToCleanException("Придется удалить все точки");
            _pointsToClean = result;
            _logger.Log("info", "найдены точки для очистки");
            Console.WriteLine(result.Count + " " + points.Count);
            return _pointsToClean;
        }

        public List<RestorePoint> GetPointsToCleanByOneOf(List<RestorePoint> points, params ICleanerStrategy[] strategies)
        {
            var result = new List<RestorePoint>();
            foreach (ICleanerStrategy strategy in strategies)
            {
                foreach (RestorePoint point in strategy.FindPointsToClean(points))
                {
                    if (!result.Contains(point))
                    {
                        result.Add(point);
                    }
                }
            }

            if (result.Count == points.Count) throw new AllPointsToCleanException("По данному алгоритму придется удалить все restore point");
            _pointsToClean = result;
            _logger.Log("info", "найдены точки для очистки");
            return _pointsToClean;
        }

        public List<RestorePoint> GetPointsToCleanByAllOf(List<RestorePoint> points, params ICleanerStrategy[] strategies)
        {
            var result = new List<RestorePoint>();
            var pointsDictionary = new Dictionary<RestorePoint, int>();
            foreach (ICleanerStrategy strategy in strategies)
            {
                foreach (RestorePoint point in points)
                {
                    if (pointsDictionary.ContainsKey(point)) pointsDictionary[point] += 1;
                    else pointsDictionary.Add(point, 1);
                }
            }

            foreach (KeyValuePair<RestorePoint, int> pair in pointsDictionary)
            {
                if (pair.Value > 1) result.Add(pair.Key);
            }

            if (result.Count == points.Count) throw new AllPointsToCleanException("По данному алгоритму придется удалить все restore point");
            _pointsToClean = result;
            _logger.Log("info", "найдены точки для очистки");
            return result;
        }

        public List<RestorePoint> CleanPoints()
        {
            foreach (RestorePoint point in _pointsToClean)
            {
                _repository.Delete(point.GetPath() + ".zip");
            }

            _logger.Log("info", "точки очищены");
            return _pointsToClean;
        }

        public RestorePoint MergePoints(RestorePoint oldPoint, RestorePoint newPoint)
        {
            if (oldPoint.GetAlgorithm().GetName() == "Single") _repository.Delete(oldPoint.GetPath() + ".zip");
            foreach (string currentObject in oldPoint.GetStorage().GetJobObjects())
            {
                if (!newPoint.GetStorage().GetJobObjects().Contains(currentObject))
                {
                    newPoint.GetStorage().AddJobObject(currentObject);
                }
            }

            _logger.Log("info", "точки смерджены");
            _repository.Update(newPoint);
            return newPoint;
        }

        public void RestorePointToOriginalLocation(RestorePoint restorePoint)
        {
            _repository.Restore(restorePoint.GetPath() + ".zip", restorePoint.GetPath());
            _logger.Log("info", "файлы восстановлены в исходную директорию");
        }

        public void RestorePointsToNewLocation(RestorePoint restorePoint, string location)
        {
            _repository.Restore(restorePoint.GetPath() + ".zip", location);
            _logger.Log("info", "точки восстановлены в новую директорию");
        }
    }
}
