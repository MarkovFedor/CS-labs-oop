using System;
using System.IO;
using System.IO.Compression;
using Backups.Entities;

namespace Backups.Repository
{
    public class WindowsRepository
        : IRepository
    {
        public void Create(string fileNamePath, string fileName, string archiveName)
        {
            using (ZipArchive zipArchive = ZipFile.Open(archiveName, ZipArchiveMode.Create))
            {
                zipArchive.CreateEntryFromFile(fileNamePath, fileName);
            }
        }
    }
}
