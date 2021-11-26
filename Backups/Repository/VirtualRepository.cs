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

        public void Create(string fileNamePath, string fileName, string archiveName)
        {
            _fileSystem.Add(archiveName);
        }

        public List<string> GetStorages()
        {
            return _fileSystem;
        }
    }
}
