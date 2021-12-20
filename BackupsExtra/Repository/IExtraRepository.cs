using Backups.Repository;
namespace BackupsExtra.Repository
{
    public interface IExtraRepository
        : IRepository
    {
        void Delete(string filePath);
        void Restore(string filePath, string restorePath);
    }
}
