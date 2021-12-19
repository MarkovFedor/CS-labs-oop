using System.Collections.Generic;
using Backups.Entities;
using BackupsExtra.Cleaner;
namespace BackupsExtra.Backup
{
    public class RestorePointsController
    {
        private ICleanerStrategy _cleanerStrategy;
        public RestorePointsController()
        {
        }

        public List<RestorePoint> GetPointsToClean()
        {
            _cleanerStrategy = _cleanerStrategy.FindPointsToClean();

        }

        public List<RestorePoint> GetPointsToCleanByOneOf(params ICleanerStrategy[] strategies)
        {
            var points = new HashSet<RestorePoint>();
            foreach (RestorePoint strategy in strategies)
            {
                foreach ()
            }
        }

        public List<RestorePoint> GetPointsToCleanByAllOf()
        {

        }

        public void CleanPoints()
        {

        }

        public void MergePoints()
        {

        }

        public void RestorePointsToOriginalLocation()
        {

        }

        public void RestorePointsToNewLocation(string location)
        {

        }
    }
}
