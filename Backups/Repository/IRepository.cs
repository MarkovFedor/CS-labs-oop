using Backups.Entities;

namespace Backups.Repository
{
    public interface IRepository
    {
        void CreateSplit(RestorePoint restorePoint);
        void CreateSingle(RestorePoint restorePoint);
    }
}
