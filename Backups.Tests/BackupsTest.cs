using NUnit.Framework;
using Backups.Entities;
using Backups.Algorithms;
using Backups.Repository;

namespace Backups.Tests
{
    public class BackupsTest
    {
        BackupJob testJob;
        [SetUp]
        public void Setup()
        {
            testJob = new BackupJob();
        }

        [Test]
        public void FirstTestCase_ExistsTwoPointsAndThreeStorages()
        {
            VirtualRepository virtRep = new VirtualRepository();
            testJob.SetAlgorithm(new SplitAlgorithm(virtRep));
            testJob.AddJobObject("./fileA");
            testJob.AddJobObject("./fileB");
            testJob.CreateRestorePoint("SplitFileAFileB");
            testJob.RemoveJobObject("./fileA");
            testJob.CreateRestorePoint("SplitFileB");
            Assert.AreEqual(2, testJob.GetRestorePoints().Count);
            Assert.AreEqual(3, virtRep.GetStorages().Count);
        }
    }
}
