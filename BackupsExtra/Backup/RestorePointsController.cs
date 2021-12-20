using System.Collections.Generic;
using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.Log;
using BackupsExtra.Repository;
namespace BackupsExtra.Backup
{
    public class RestorePointsController
    {
        private ICleanerStrategy _cleanerStrategy;
        private List<RestorePoint> _pointsToClean;
        private Logger _logger;
        public RestorePointsController()
        {
        }

        public void SetLogger(Logger logger)
        {
            _logger = logger;
        }

        public void SetStrategy(ICleanerStrategy strategy)
        {
            _cleanerStrategy = strategy;
        }

        public List<RestorePoint> GetPointsToClean(List<RestorePoint> points)
        {
            _pointsToClean = _cleanerStrategy.FindPointsToClean(points);
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
            return result;
        }

        public void CleanPoints(IExtraRepository repository)
        {
            foreach (RestorePoint point in _pointsToClean)
            {
                repository.Delete(point.GetPath() + ".zip");
            }
        }

        public void MergePoints(RestorePoint oldPoint, RestorePoint newPoint)
        {
            if (oldPoint.GetType())
            foreach (string currentObject in oldPoint.GetStorage().GetJobObjects())
            {
                if (newPoint.GetStorage().GetJobObjects().Contains(currentObject))
                {
                    newPoint.
                }
            }
        }

        public void RestorePointToOriginalLocation(RestorePoint restorePoint, IExtraRepository repository)
        {
            repository.Restore(restorePoint.GetPath() + ".zip", restorePoint.GetPath());
        }

        public void RestorePointsToNewLocation(RestorePoint restorePoint, IExtraRepository repository, string location)
        {
            repository.Restore(restorePoint.GetPath() + ".zip", location);
        }
    }
}
