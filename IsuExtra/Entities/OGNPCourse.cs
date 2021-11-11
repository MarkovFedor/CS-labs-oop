using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Entities
{
    public class OGNPCourse
    {
        private string _name;
        private Megafaculty _megafaculty;
        private List<OGNPGroup> _groups;
        public OGNPCourse(string name, Megafaculty megafaculty)
        {
            _name = name;
            _groups = new List<OGNPGroup>();
            _megafaculty = megafaculty;

            _groups.Add(new OGNPGroup(_groups.Count.ToString(), megafaculty));
        }

        public bool SubscribeStudent(Student student)
        {
            foreach (OGNPGroup group in _groups)
            {
                if (group.IsAllowToSubscribe(student))
                {
                    return true;
                }
            }

            return false;
        }

        public void SignOutStudent(Student student)
        {
            foreach (OGNPGroup group in _groups)
            {
                foreach (Student guesStudent in group.GetStudents())
                {
                    if (guesStudent == student)
                    {
                        group.GetStudents().Remove(student);
                    }
                }
            }
        }

        public Megafaculty GetMegafaculty()
        {
            return _megafaculty;
        }

        public List<OGNPGroup> GetGroups()
        {
            return _groups;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
