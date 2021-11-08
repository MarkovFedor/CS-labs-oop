using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Entities;

namespace IsuExtra
{
    public interface IIsuExtraService
    {
        public OGNPCourse CreateOGNP(Megafaculty faculty, string courseName);
        public void SubscribeStudentOnOGNP(Student student, OGNPCourse course);
        public void UnsubscribeStudentOGNP(Student student, OGNPCourse course);
        public List<OGNPGroup> GetGroupsOnCourse(OGNPCourse course);
        public List<Student> GetStudentsInOGNPGroup(OGNPGroup group);
        public List<Student> GetNotSubscribedStudents();
        public Group AddGroup(string groupName);
    }
}
