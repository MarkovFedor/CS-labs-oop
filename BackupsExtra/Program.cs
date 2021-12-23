using System;
using System.Collections.Generic;
using Backups.Algorithms;
using BackupsExtra.Backup;
using BackupsExtra.Cleaner;
using BackupsExtra.Log;
using BackupsExtra.Repository;
namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            var currentState = new List<BackupJobExtra>();
            var firstJob = new BackupJobExtra();
            var logger = new Logger();
            var repository = new VirtualExtraRepository();
            var restorePointsControler = new RestorePointsController();
            restorePointsControler.SetLogger(logger);
            restorePointsControler.SetRepository(repository);
            logger.AddLoggerStrategy(new ConsoleLogger());
            var backupJobBuilder = new BackupJobExtraBuilder();
            firstJob = backupJobBuilder
                .AddDirectory(@"C:\Somefolder\Backup\")
                .AddAlgorithm(new SplitAlgorithm(new VirtualExtraRepository()))
                .AddRepository(repository)
                .AddLogger(logger)
                .AddRestorePointController(restorePointsControler)
                .AddCleanerStrategy(new CountCleanerStrategy(4))
                .AddJobObject(@"C:\Somefolder\2.txt")
                .AddJobObject(@"C:\Somefolder\3.txt")
                .Build();
            firstJob.CreateRestorePoint("TestPoint");
            firstJob.CreateRestorePoint("TestPoint1");
            firstJob.SelectPointsToClean();
        }
    }
}
