using Backups.Entities;

namespace Backups.Algorithms
{
    public interface IAlgorithm
    {
        void Save(RestorePoint restorePoint);
    }
}
