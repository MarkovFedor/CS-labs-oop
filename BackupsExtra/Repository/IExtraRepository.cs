using Backups.Entities;
using Backups.Repository;
namespace BackupsExtra.Repository
{
    public interface IExtraRepository
        : IRepository
    {
        void Delete(string filePath);
        void Restore(string filePath, string restorePath);

        void Update(RestorePoint restorePoint);
    }
}
