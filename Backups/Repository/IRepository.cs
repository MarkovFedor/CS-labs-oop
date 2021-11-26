using System.IO.Compression;

namespace Backups.Repository
{
    public interface IRepository
    {
        void Create(string fileNamePath, string fileName, string archiveName);
    }
}
