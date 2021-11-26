using Backups.Entities;
using Backups.Repository;

namespace Backups.Algorithms
{
    public class SplitAlgorithm : IAlgorithm
    {
        private IRepository _repository;
        public SplitAlgorithm(IRepository repository)
        {
            _repository = repository;
        }

        public void Save(RestorePoint restorePoint)
        {
            _repository.CreateSplit(restorePoint);
        }
    }
}
