using Isu.Services;
using Isu.Tools;
using NUnit.Framework;
using Isu.Entity;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group m3110 = _isuService.AddGroup("M3110");
            _isuService.AddStudent(m3110, "fedor");
            Student fedor = _isuService.FindStudent("fedor");
            Assert.AreEqual("M3110", fedor.GetGroup().GetGroupName());
            Assert.Contains(fedor, m3110.GetStudents());
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            var m3110 = _isuService.AddGroup("M3110");
            for(int i = 0; i < 31; i++)
                {
                    _isuService.AddStudent(m3110, i.ToString());
                }
            Assert.Catch<IsuException>(() =>
            {
                _isuService.AddStudent(m3110, "fedor");
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                var breakingGroup = _isuService.AddGroup("M3824");
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Assert.Catch<IsuException>(() =>
            {
                var m3110 = _isuService.AddGroup("M3110");
                var m3111 = _isuService.AddGroup("M3111");
                var alex = _isuService.AddStudent(m3110, "alex");

                _isuService.ChangeStudentGroup(alex, m3111);
                _isuService.ChangeStudentGroup(alex, m3111);
            });
        }
    }
}