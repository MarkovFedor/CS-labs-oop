using System.Collections.Generic;
using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.Log;
namespace BackupsExtra.Backup
{
    public class BackupJobExtra
        : BackupJob
    {
        private Logger _logger;
        private RestorePointsController _restorePointsController;

        public BackupJobExtra()
        {
        }

        public void SetRestorePointsController(RestorePointsController restorePointsController)
        {
            _restorePointsController = restorePointsController;
        }

        public void SetLogger(Logger logger)
        {
            _logger = logger;
        }

        public void SetCleanerStrategy(ICleanerStrategy cleanerStrategy)
        {
            _restorePointsController.SetStrategy(cleanerStrategy);
        }

        public void MergePoints(RestorePoint oldPoint, RestorePoint restorePoint)
        {
            _logger.Log("info", "начало merge points");
            RestorePoint point = _restorePointsController.MergePoints(oldPoint, restorePoint);
            GetRestorePoints().Add(point);
        }

        public void SelectPointsToClean()
        {
            _restorePointsController.GetPointsToClean(GetRestorePoints());
        }

        public void SelectPointsToCleanByOneOf(params ICleanerStrategy[] strategies)
        {
            _restorePointsController.GetPointsToCleanByOneOf(GetRestorePoints(), strategies);
        }

        public void SelectPointsToCleanByAllOf(params ICleanerStrategy[] strategies)
        {
            _restorePointsController.GetPointsToCleanByAllOf(GetRestorePoints(), strategies);
        }

        public void Clean()
        {
            List<RestorePoint> pointToClean = _restorePointsController.CleanPoints();
            foreach (RestorePoint point in pointToClean)
            {
                GetRestorePoints().Remove(point);
            }
        }
    }
}
