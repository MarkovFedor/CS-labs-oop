using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Cleaner
{
    public interface ICleanerStrategy
    {
        List<RestorePoint> FindPointsToClean(List<RestorePoint> points);
    }
}
