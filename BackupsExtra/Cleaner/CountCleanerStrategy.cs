using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Cleaner
{
    public class CountCleanerStrategy
        : ICleanerStrategy
    {
        private int _pointCountLimit;
        public CountCleanerStrategy(int limit)
        {
            _pointCountLimit = limit;
        }

        public List<RestorePoint> FindPointsToClean(List<RestorePoint> points)
        {
            var result = new List<RestorePoint>();
            if (points.Count > _pointCountLimit)
            {
                result = points.GetRange(points.Count - 1 - _pointCountLimit, _pointCountLimit);
            }

            return result;
        }
    }
}
