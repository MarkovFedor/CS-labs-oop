using System;
using System.IO;
using System.IO.Compression;
using Backups.Entities;

namespace Backups.Algorithms
{
    public class SingleAlgorithmRepository : IAlgorithmRepository
    {
        public SingleAlgorithmRepository() { }
        public void Save(RestorePoint restorePoint)
        {
            string dirName = restorePoint.GetDirName();
            dirName = GenerateUniqDir(dirName);
            Console.WriteLine(dirName);
            string archName = dirName + "_" + "arch.zip";
            Directory.CreateDirectory(dirName);
            Console.WriteLine(archName);
            foreach (string storeObject in restorePoint.GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                File.Copy(storeObject, dirName + "/" + clearStoreObject);
            }

            ZipFile.CreateFromDirectory(dirName, archName);
            Directory.Delete(dirName, true);
        }

        private string GenerateUniqDir(string dirName)
        {
            int index = 1;
            while (Directory.Exists(dirName + "_" + index) | Directory.Exists(dirName + "_" + index + "_" + "arch.zip"))
            {
                Console.WriteLine(dirName + "_" + index);
                Console.WriteLine(dirName + "_" + index + "_" + "arch.zip");
                ++index;
            }

            dirName = dirName + "_" + index;
            return dirName;
        }
    }
}
