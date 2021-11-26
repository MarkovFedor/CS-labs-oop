using System;
using System.IO;
using System.IO.Compression;
using Backups.Entities;

namespace Backups.Repository
{
    public class WindowsRepository
        : IRepository
    {
        public void CreateSingle(RestorePoint restorePoint)
        {
            string dirName = restorePoint.GetDirName();
            dirName = GenerateUniqDir(dirName);
            string archName = dirName + "_" + "arch.zip";
            Directory.CreateDirectory(dirName);
            foreach (string storeObject in restorePoint.GetStorage().GetJobObjects())
            {
                string[] paths = storeObject.Split("/");
                string clearStoreObject = paths[paths.Length - 1];
                File.Copy(storeObject, dirName + "/" + clearStoreObject);
            }

            ZipFile.CreateFromDirectory(dirName, archName);
            Directory.Delete(dirName, true);
        }

        public void CreateSplit(RestorePoint restorePoint)
        {
            string dirName = restorePoint.GetDirName();
            dirName = GenerateUniqDir(dirName);
            Directory.CreateDirectory(dirName);
            foreach (string storeObject in restorePoint.GetStorage().GetJobObjects())
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
