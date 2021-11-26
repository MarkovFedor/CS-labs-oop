using Backups.Entities;
using Backups.Repository;

namespace Backups.Algorithms
{
    public class SingleAlgorithm : IAlgorithm
    {
        private IRepository _repository;
        public SingleAlgorithm(IRepository repository)
        {
            _repository = repository;
        }

        public void Save(RestorePoint restorePoint)
        {
            _repository.CreateSingle(restorePoint);
        }
    }
}
