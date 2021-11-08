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

        public OGNPGroup(string name, Megafaculty megafaculty)
        {
            _name = name;
            _students = new List<Student>();
            _megafaculty = megafaculty;
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

        public bool AllowToSubscribe(Student student)
        {
            if (_students.Count < MAXSTUDENTSINGROUP && student.GetMegafaculty().GetID() != _megafaculty.GetID())
            {
                return true;
            }

            return false;
        }
    }
}
