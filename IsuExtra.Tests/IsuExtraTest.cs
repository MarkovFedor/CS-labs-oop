using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using IsuExtra;
using IsuExtra.Entities;

namespace IsuExtra.Tests
{
    public class Tests
    {
        IsuExtraService _isu;
        [SetUp]
        public void Setup()
        {
            _isu = new IsuExtraService();
        }

        [Test]
        public void AddingNewOGNP_NewOGNP()
        {
            Megafaculty faculty = _isu.CreateMegafaculty("FITIP", 'M');
            faculty.CreateOGNPCourse("Some name for course");

            Assert.AreEqual(1, faculty.GetCourses().Count);

            faculty.CreateOGNPCourse("Another name for course");

            Assert.AreEqual(2, faculty.GetCourses().Count);
        }

        [Test]
        public void SubscribeStudentOnOGNP_StudentSubscribed()
        {
            Megafaculty faculty = _isu.CreateMegafaculty("FITIP", 'N');
            Megafaculty anotherFaculty = _isu.CreateMegafaculty("some", 'M');
            OGNPCourse course = faculty.CreateOGNPCourse("Some name for course");
            Group testGroup = _isu.AddGroup("M3210");

            Student testStudent = _isu.AddStudent("Test", testGroup, anotherFaculty);
            _isu.SubscribeStudentOnOGNP(testStudent, course);

            Assert.AreEqual(course, testStudent.GetFirstCourse());
        }
        [Test]
        public void UnsubscribeStudentFromOGNP_StudentUnsubscribed()
        {
            Megafaculty faculty = _isu.CreateMegafaculty("FITIP", 'N');
            Megafaculty anotherFaculty = _isu.CreateMegafaculty("some", 'M');
            OGNPCourse course = faculty.CreateOGNPCourse("Some name for course");
            Group testGroup = _isu.AddGroup("M3210");

            Student testStudent = _isu.AddStudent("Test", testGroup, anotherFaculty);
            _isu.SubscribeStudentOnOGNP(testStudent, course);

            Assert.AreEqual(course, testStudent.GetFirstCourse());

            _isu.UnsubscribeStudentOGNP(testStudent, course);

            Assert.AreEqual(null, testStudent.GetFirstCourse());
        }

        [Test]
        public void GetNotSubscribedStudents()
        {
            Megafaculty faculty = _isu.CreateMegafaculty("FITIP", 'M');
            Group testGroup = _isu.AddGroup("M3210");
            _isu.AddStudent("Test", testGroup, faculty);
            _isu.AddStudent("Test2", testGroup, faculty);
            _isu.AddStudent("Test3", testGroup, faculty);
            _isu.AddStudent("Test4", testGroup, faculty);
            _isu.AddStudent("Test5", testGroup, faculty);

            Assert.AreEqual(5, _isu.GetNotSubscribedStudents().Count);

        }
    }
}
