using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Exceptions;

namespace IsuExtra.Entities
{
    public class OGNPGroup
    {
        private static readonly int MAXSTUDENTSINGROUP = 20;
        private string _name;
        private List<Student> _students;
        private Megafaculty _megafaculty;
        private List<Lesson> _schedule;
        public OGNPGroup(string name, Megafaculty megafaculty)
        {
            _name = name;
            _students = new List<Student>();
            _megafaculty = megafaculty;
            _schedule = new List<Lesson>();
        }

        public string GetName()
        {
            return _name;
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            foreach (Student currentStudent in _students)
            {
                if (currentStudent == student)
                {
                    throw new StudentInGroupException("Студент в группе");
                }
            }

            _students.Add(student);
        }

        public bool IsAllowToSubscribe(Student student)
        {
            if (_students.Count < MAXSTUDENTSINGROUP && student.GetMegafaculty().GetID() != _megafaculty.GetID() && IsAllowSchedule(student.GetGroup().GetSchedule()))
            {
                return true;
            }

            return false;
        }

        public void AddLesson(Lesson lesson)
        {
            if (IsAllowLesson(lesson))
            {
                _schedule.Add(lesson);
            }
        }

        private bool IsAllowSchedule(List<Lesson> otherSchedule)
        {
            foreach (Lesson lesson in otherSchedule)
            {
                if (!IsAllowLesson(lesson))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAllowLesson(Lesson lesson)
        {
            foreach (Lesson curLesson in _schedule)
            {
                if (curLesson.GetStart() < lesson.GetStart() &&
                    curLesson.GetEnd() > lesson.GetStart())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
