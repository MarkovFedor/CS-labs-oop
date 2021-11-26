using System;
using System.Collections.Generic;
using System.Text;
using Backups.Entities;

namespace Backups.Repository
{
    public class VirtualRepository
        : IRepository
    {
        private List<string> _fileSystem;
        public VirtualRepository()
        {
            _fileSystem = new List<string>();
        }

        public void CreateSplit(RestorePoint restorePoint)
        {
            string dir = restorePoint.GetDirName();
            Storage storage = restorePoint.GetStorage();
            List<string> jobObjects = storage.GetJobObjects();
            foreach (string jobObject in jobObjects)
            {
                string[] paths = jobObject.Split("/");
                string fileName = paths[paths.Length - 1];
                _fileSystem.Add(dir + fileName + ".zip");
            }
        }

        public void CreateSingle(RestorePoint restorePoint)
        {
            string dir = restorePoint.GetDirName();
            Storage storage = restorePoint.GetStorage();
            List<string> jobObjects = storage.GetJobObjects();
            foreach (string jobObject in jobObjects)
            {
                string[] paths = jobObject.Split("/");
                string fileName = paths[paths.Length - 1];
                _fileSystem.Add(dir + fileName + ".zip");
            }
        }

        public List<string> GetStorages()
        {
            return _fileSystem;
        }
    }
}
