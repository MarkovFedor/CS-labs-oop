using Backups.Algorithms;
using Backups.Repository;
using BackupsExtra.Log;
namespace BackupsExtra.Backup
{
    public class BackupJobExtraBuilder
    {
        private BackupJobExtra _backupJob;

        public BackupJobExtraBuilder()
        {
            _backupJob = new BackupJobExtra();
        }

        public BackupJobExtraBuilder AddDirectory(string dir)
        {
            _backupJob.SetDir(dir);
            return this;
        }

        public BackupJobExtraBuilder AddStorageAlgorithm(IAlgorithm algorithm)
        {
            _backupJob.SetAlgorithm(algorithm);
            return this;
        }

        public BackupJobExtraBuilder AddRepository(IRepository repository)
        {
            _backupJob.SetRepository(repository);
            return this;
        }

        public BackupJobExtraBuilder AddLogger(Logger logger)
        {
            _backupJob.SetLogger(logger);
            return this;
        }

        public BackupJobExtra Build()
        {
            BackupJobExtra result = _backupJob;
            _backupJob = new BackupJobExtra();
            return result;
        }
    }
}
