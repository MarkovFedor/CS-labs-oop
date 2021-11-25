using System.Collections.Generic;

namespace Backups.Entities
{
    public interface IBackupJob
    {
        void CreateRestorePoint(string name);
        void AddJobObject(string path);
        void RemoveJobObject(string path);
        List<RestorePoint> GetRestorePoints();
        List<string> GetJobObjects();
    }
}
