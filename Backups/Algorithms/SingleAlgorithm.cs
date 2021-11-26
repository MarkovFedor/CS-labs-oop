using System.IO;
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
            string dirName = restorePoint.GetDirName();
            foreach (string storeObject in restorePoint.GetStorage().GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                string archName = dirName + "/" + clearStoreObject + ".zip";
                _repository.Create(storeObject, clearStoreObject, archName);
            }
        }
    }
}
