using Backups.Algorithms;
using Backups.Repository;
using BackupsExtra.Cleaner;
using BackupsExtra.Log;

namespace BackupsExtra.Backup
{
    public class BackupJobExtraBuilder
        : IBackupExtraBuilder
    {
        private BackupJobExtra _backupJob;
        public BackupJobExtraBuilder()
        {
            _backupJob = new BackupJobExtra();
        }

        public BackupJobExtraBuilder AddAlgorithm(IAlgorithm algorithm)
        {
            _backupJob.SetAlgorithm(algorithm);
            return this;
        }

        public BackupJobExtraBuilder AddCleanerStrategy(ICleanerStrategy cleanerStrategy)
        {
            _backupJob.SetCleanerStrategy(cleanerStrategy);
            return this;
        }

        public BackupJobExtraBuilder AddDirectory(string dir)
        {
            _backupJob.SetDir(dir);
            return this;
        }

        public BackupJobExtraBuilder AddRestorePointController(RestorePointsController restorePointsController)
        {
            _backupJob.SetRestorePointsController(restorePointsController);
            return this;
        }

        public BackupJobExtraBuilder AddLogger(Logger logger)
        {
            _backupJob.SetLogger(logger);
            return this;
        }

        public BackupJobExtraBuilder AddRepository(IRepository repository)
        {
            _backupJob.SetRepository(repository);
            return this;
        }

        public BackupJobExtraBuilder AddJobObject(string path)
        {
            _backupJob.AddJobObject(path);
            return this;
        }

        public BackupJobExtraBuilder RemoveJobObject(string path)
        {
            _backupJob.RemoveJobObject(path);
            return this;
        }

        public BackupJobExtraBuilder SetRootBackupJob(BackupJobExtra backupJob)
        {
            _backupJob = backupJob;
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
