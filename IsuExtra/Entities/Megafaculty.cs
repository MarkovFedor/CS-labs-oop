using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Entities
{
    public class Megafaculty
    {
        private static int iD = 1;
        private int _id;
        private char _letter;
        private string _name;
        private List<OGNPCourse> _courses;
        private List<Group> _groups;
        public Megafaculty(string name, char letter)
        {
            _id = iD++;
            _letter = letter;
            _name = name;
            _courses = new List<OGNPCourse>();
            _groups = new List<Group>();
        }

        public List<OGNPCourse> GetCourses()
        {
            return _courses;
        }

        public void PutGroup(Group group)
        {
            _groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            _groups.Remove(group);
        }

        public string GetName()
        {
            return _name;
        }

        public char GetLetter()
        {
            return _letter;
        }

        public int GetID()
        {
            return _id;
        }

        public OGNPCourse CreateOGNPCourse(string name)
        {
            var course = new OGNPCourse(name, this);
            _courses.Add(course);
            return course;
        }
    }
}
