using Backups.Entities;
using Backups.Repository;
namespace BackupsExtra.Repository
{
    public class VirtualExtraRepository
        : VirtualRepository, IExtraRepository
    {
        public void Delete(string filePath)
        {
            GetStorages().Remove(filePath);
        }

        public void Restore(string filePath, string location)
        {
            GetStorages().Remove(filePath);
            GetStorages().Add(location);
        }

        public void Update(RestorePoint restorePoint)
        {
        }
    }
}
