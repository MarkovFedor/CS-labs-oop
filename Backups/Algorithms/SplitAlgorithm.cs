using System.IO.Compression;
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
            string dirName = restorePoint.GetDirName();
            foreach (string storeObject in restorePoint.GetStorage().GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                string archName = dirName + "/" + clearStoreObject + ".zip";
                _repository.Create(storeObject, clearStoreObject, archName);
            }
        }

        public string GetName()
        {
            return "Split";
        }
    }
}
