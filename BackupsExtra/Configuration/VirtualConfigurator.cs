using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Configuration
{
    public class VirtualConfigurator
        : IConfigurator
    {
        private List<BackupJob> _storage;
        public VirtualConfigurator()
        {
            _storage = new List<BackupJob>();
        }

        public List<BackupJob> ImportConfiguration()
        {
            return _storage;
        }

        public void ExportConfiguration(List<BackupJob> items)
        {
            _storage = items;
        }
    }
}
