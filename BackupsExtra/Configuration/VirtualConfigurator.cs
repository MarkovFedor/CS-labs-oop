using System.Collections.Generic;
using BackupsExtra.Backup;
namespace BackupsExtra.Configuration
{
    public class VirtualConfigurator
        : IConfigurator
    {
        private List<BackupJobExtra> _storage;
        public VirtualConfigurator()
        {
            _storage = new List<BackupJobExtra>();
        }

        public List<BackupJobExtra> ImportConfiguration()
        {
            return _storage;
        }

        public void ExportConfiguration(List<BackupJobExtra> items)
        {
            _storage = items;
        }
    }
}
