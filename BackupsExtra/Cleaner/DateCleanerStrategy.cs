using System;
using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Cleaner
{
    public class DateCleanerStrategy
        : ICleanerStrategy
    {
        private DateTime _timeLimit;
        public DateCleanerStrategy(DateTime limit)
        {
            _timeLimit = limit;
        }

        public List<RestorePoint> FindPointsToClean(List<RestorePoint> points)
        {
            var result = new List<RestorePoint>();
            foreach (RestorePoint point in points)
            {
                if (point.GetDate() < _timeLimit)
                {
                    result.Add(point);
                }
            }

            return result;
        }
    }
}
