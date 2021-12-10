using System;
using Backups.Entities;

namespace BackupsExtra.Configuration
{
    public class XmlConfiguration
        : IConfigurator
    {
        private string _configurationFileName;
        private BackupJob _state;
        public void ExportConfiguration()
        {
            throw new NotImplementedException();
        }

        public void ImportConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
