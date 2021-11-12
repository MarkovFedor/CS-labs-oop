using System.Collections.Generic;

namespace IsuExtra.Entities
{
    public class Group : Isu.Entity.Group
    {
        private Megafaculty _megafaculty;
        private List<Student> _students;
        private List<Lesson> _schedule;
        public Group(string name)
            : base(name)
        {
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
            if (_students.Count < GetMaxCountOfStudents())
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
