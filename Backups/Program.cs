using Backups.Algorithms;
using Backups.Entities;
using Backups.Repository;
namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var testJob = new BackupJob();
            var virtRep = new VirtualRepository();
            testJob.SetAlgorithm(new SplitAlgorithm(virtRep));
            testJob.AddJobObject("./fileA");
            testJob.AddJobObject("./fileB");
            testJob.CreateRestorePoint("SplitFileAFileB");
            testJob.RemoveJobObject("./fileA");
            testJob.CreateRestorePoint("SplitFileB");
        }
    }
}
