using System;
using System.IO;
using System.IO.Compression;
using Backups.Entities;
namespace Backups.Algorithms
{
    public class SplitAlgorithmRepository : IAlgorithmRepository
    {
        public SplitAlgorithmRepository() { }
        public void Save(RestorePoint restorePoint)
        {
            string dirName = restorePoint.GetDirName();
            dirName = GenerateUniqDir(dirName);
            Directory.CreateDirectory(dirName);
            foreach (string storeObject in restorePoint.GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                string archName = dirName + "/" + clearStoreObject + ".zip";
                using (ZipArchive zipArchive = ZipFile.Open(archName, ZipArchiveMode.Create))
                {
                    string pathFileToAdd = storeObject;
                    string nameFileToAdd = clearStoreObject;
                    zipArchive.CreateEntryFromFile(pathFileToAdd, nameFileToAdd);
                }
            }
        }

        private string GenerateUniqDir(string dirName)
        {
            int index = 1;
            while (Directory.Exists(dirName + "_" + index))
            {
                Console.WriteLine(dirName + "_" + index);
                ++index;
            }

            dirName = dirName + "_" + index;
            return dirName;
        }
    }
}
