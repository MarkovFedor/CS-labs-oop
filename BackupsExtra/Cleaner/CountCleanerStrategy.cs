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
            if (points.Count <= _pointCountLimit) return points;
            if (points.Count > _pointCountLimit)
            {
                result = points.GetRange(0, points.Count - _pointCountLimit);
            }

            return result;
        }
    }
}
