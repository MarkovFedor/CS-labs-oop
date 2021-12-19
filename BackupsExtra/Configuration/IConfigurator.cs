using System.Collections.Generic;
using Backups.Entities;
namespace BackupsExtra.Configuration
{
    public interface IConfigurator
    {
        List<BackupJob> ImportConfiguration();
        void ExportConfiguration(List<BackupJob> items);
    }
}
