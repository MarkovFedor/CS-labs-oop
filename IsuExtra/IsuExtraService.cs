using System.Collections.Generic;
using IsuExtra.Entities;
using IsuExtra.Exceptions;

namespace IsuExtra
{
    public class IsuExtraService : IIsuExtraService
    {
        private List<Megafaculty> _megafaculties;
        private List<Student> _students;
        public IsuExtraService()
        {
            _megafaculties = new List<Megafaculty>();
            _students = new List<Student>();
        }

        public Megafaculty CreateMegafaculty(string name, char letter)
        {
            var newFaculty = new Megafaculty(name, letter);
            _megafaculties.Add(newFaculty);
            return newFaculty;
        }

        public OGNPCourse CreateOGNP(Megafaculty faculty, string courseName)
        {
            OGNPCourse newCourse = faculty.CreateOGNPCourse(courseName);
            return newCourse;
        }

        public List<Student> GetNotSubscribedStudents()
        {
            var res = new List<Student>();
            foreach (Student student in _students)
            {
                if (student.GetFirstCourse() == null || student.GetSecondCourse() == null)
                {
                    res.Add(student);
                }
            }

            return res;
        }

        public List<Student> GetStudentsInOGNPGroup(OGNPGroup group)
        {
            return group.GetStudents();
        }

        public List<OGNPGroup> GetGroupsOnCourse(OGNPCourse course)
        {
            return course.GetGroups();
        }

        public void SubscribeStudentOnOGNP(Student student, OGNPCourse course)
        {
            student.SignUpForCourse(course);
        }

        public void UnsubscribeStudentOGNP(Student student, OGNPCourse course)
        {
            student.SignOutFromCourse(course);
        }

        public Group AddGroup(string groupName)
        {
            foreach (Megafaculty megafaculty in _megafaculties)
            {
                if (megafaculty.GetLetter() == groupName[0])
                {
                    var newGroup = new Group(groupName);
                    megafaculty.PutGroup(newGroup);
                    newGroup.UpdateMegafaculty(megafaculty);
                    return newGroup;
                }
            }

            throw new IncorrectGroupNameException("Неверное именование группы (факультета с такой буквой не существует)");
        }

        public Student AddStudent(string name, Group group, Megafaculty megafaculty)
        {
            var newStudent = new Student(name, group, megafaculty);
            _students.Add(newStudent);
            return newStudent;
        }
    }
}
