using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Entities;

namespace IsuExtra
{
    public interface IIsuExtraService
    {
        OGNPCourse CreateOGNP(Megafaculty faculty, string courseName);
        void SubscribeStudentOnOGNP(Student student, OGNPCourse course);
        void UnsubscribeStudentOGNP(Student student, OGNPCourse course);
        List<OGNPGroup> GetGroupsOnCourse(OGNPCourse course);
        List<Student> GetStudentsInOGNPGroup(OGNPGroup group);
        List<Student> GetNotSubscribedStudents();
        Group AddGroup(string groupName);
    }
}
