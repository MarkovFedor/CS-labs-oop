using Backups.Entities;

namespace Backups.Algorithms
{
    public interface IAlgorithmRepository
    {
        void Save(RestorePoint restorePoint);
    }
}
