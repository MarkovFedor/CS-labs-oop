using System.Collections.Generic;
using BackupsExtra.Backup;
namespace BackupsExtra.Configuration
{
    public interface IConfigurator
    {
        List<BackupJobExtra> ImportConfiguration();
        void ExportConfiguration(List<BackupJobExtra> items);
    }
}
