using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BackupsExtra.Backup;
using BackupsExtra.Configuration;
using BackupsExtra.Log;
using Backups.Algorithms;
using BackupsExtra.Repository;
using BackupsExtra.Cleaner;
using BackupsExtra.Exceptions;
namespace BackupsExtra.Tests
{
    public class BackupsExtraTest
    {
        private BackupJobExtra _backupJob;
        [SetUp]
        public void Setup()
        {
            var logger = new Logger();
            var repository = new VirtualExtraRepository();
            var restorePointsControler = new RestorePointsController();
            restorePointsControler.SetLogger(logger);
            restorePointsControler.SetRepository(repository);
            logger.AddLoggerStrategy(new ConsoleLogger());
            var backupJobBuilder = new BackupJobExtraBuilder();
            _backupJob = backupJobBuilder
                .AddDirectory(@"C:\Somefolder\Backup\")
                .AddAlgorithm(new SplitAlgorithm(new VirtualExtraRepository()))
                .AddRepository(repository)
                .AddLogger(logger)
                .AddRestorePointController(restorePointsControler)
                .AddCleanerStrategy(new CountCleanerStrategy(4))
                .AddJobObject(@"C:\Somefolder\2.txt")
                .AddJobObject(@"C:\Somefolder\3.txt")
                .Build();
        }
        [Test]
        public void NeedToCleanAllPoints_CatchAllPointsToCleanException()
        {
            _backupJob.CreateRestorePoint("TestPoint");
            Assert.Catch<AllPointsToCleanException>(() =>
            {
                _backupJob.SelectPointsToClean();
            });
        }

        [Test]
        public void CleaningPointsByCount_CleanSelectedPoints()
        {
            _backupJob.CreateRestorePoint("TestPoint1");
            _backupJob.CreateRestorePoint("TestPoint2");
            _backupJob.CreateRestorePoint("TestPoint3");
            _backupJob.CreateRestorePoint("TestPoint4");
            _backupJob.CreateRestorePoint("TestPoint5");
            Assert.AreEqual(5, _backupJob.GetRestorePoints().Count);
            _backupJob.SelectPointsToClean();
            _backupJob.Clean();
            Assert.AreEqual(4, _backupJob.GetRestorePoints().Count);
        }

        [Test]
        public void MergeTwoPoints_GetNewPointMerged()
        {
            _backupJob.CreateRestorePoint("TestPoint1");
            _backupJob.CreateRestorePoint("TestPoint2");
            var backupJobBuilder = new BackupJobExtraBuilder();
            _backupJob = backupJobBuilder
                .SetRootBackupJob(_backupJob)
                .AddJobObject(@"C:\Somefolder\3.txt")
                .Build();
            _backupJob.CreateRestorePoint("TestPoint3");
            _backupJob.MergePoints(_backupJob.GetRestorePoints()[1], _backupJob.GetRestorePoints()[2]);
            Assert.AreEqual(4, _backupJob.GetRestorePoints().Count);
        }
    }
}
