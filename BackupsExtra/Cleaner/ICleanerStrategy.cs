using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Cleaner
{
    public interface ICleanerStrategy
    {
        public void Clean();
        public List<RestorePoint> GetToCleanPoints();
    }
}
