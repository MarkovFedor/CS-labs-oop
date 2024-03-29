﻿using Backups.Algorithms;
using Backups.Repository;
using BackupsExtra.Cleaner;
using BackupsExtra.CustomLog;
namespace BackupsExtra.Backup
{
    public interface IBackupExtraBuilder
    {
        BackupJobExtraBuilder AddDirectory(string dir);
        BackupJobExtraBuilder AddAlgorithm(IAlgorithm algorithm);
        BackupJobExtraBuilder AddRepository(IRepository repository);
        BackupJobExtraBuilder AddRestorePointController(RestorePointsManager restorePointsController);
        BackupJobExtraBuilder AddLogger(Logger logger);
        BackupJobExtraBuilder AddCleanerStrategy(ICleanerStrategy cleanerStrategy);
        BackupJobExtraBuilder AddJobObject(string path);
        BackupJobExtraBuilder RemoveJobObject(string path);
        BackupJobExtraBuilder SetRootBackupJob(BackupJobExtra backupJob);
    }
}
