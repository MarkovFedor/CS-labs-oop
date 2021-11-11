using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Entities
{
    public class Group
    {
        public static readonly int MAXSTUDENTCOUNT = 20;
        private Megafaculty _megafaculty;
        private string _name;
        private List<Student> _students;
        private List<Lesson> _schedule;
        public Group(string name)
        {
            _name = name;
            _students = new List<Student>();
            _schedule = new List<Lesson>();
        }

        public void AddLesson(Lesson lesson)
        {
            if (IsAllowLesson(lesson))
            {
                _schedule.Add(lesson);
            }
        }

        public void UpdateMegafaculty(Megafaculty megafaculty)
        {
            _megafaculty = megafaculty;
        }

        public Megafaculty GetMegafaculty()
        {
            return _megafaculty;
        }

        public void PutStudent(Student student)
        {
            if (_students.Count < MAXSTUDENTCOUNT)
            {
                _students.Add(student);
            }
        }

        public List<Lesson> GetSchedule()
        {
            return _schedule;
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
