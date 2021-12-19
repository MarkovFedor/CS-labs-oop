using Backups.Entities;
using BackupsExtra.Cleaner;
using BackupsExtra.Log;
namespace BackupsExtra.Backup
{
    public class BackupJobExtra
        : BackupJob
    {
        private Logger _logger;
        private ICleanerStrategy _primaryCleanerStrategy;

        public BackupJobExtra()
        {
        }

        public void SetLogger(Logger logger)
        {
            _logger = logger;
        }

        public void SetCleanerStrategy(ICleanerStrategy cleanerStrategy)
        {
            _primaryCleanerStrategy = cleanerStrategy;
        }

        public void MergePoints(string oldRestorePoint)
        {

        }
    }
}
