using System.IO;
using Backups.Entities;
using Backups.Repository;
namespace Backups.Algorithms
{
    public class SingleAlgorithm : IAlgorithm
    {
        private IRepository _repository;
        private AlgorithmType _name;
        public SingleAlgorithm(IRepository repository)
        {
            _repository = repository;
            _name = AlgorithmType.SINGLE;
        }

        public void Save(RestorePoint restorePoint)
        {
            string dirName = restorePoint.GetDirName();
            foreach (string storeObject in restorePoint.GetStorage().GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                string archName = dirName + "/" + clearStoreObject + ".zip";
                _repository.Create(storeObject, clearStoreObject, archName);
            }
        }

        public AlgorithmType GetName()
        {
            return _name;
        }
    }
}
