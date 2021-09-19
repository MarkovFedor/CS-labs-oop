using System;
using System.Collections.Generic;

namespace Isu.Entity
{
    public class Student
    {
        private static int iD;
        private string _nameOfStudent;
        private int _id;
        private Group _group;

        public Student(string name, Group group)
        {
            _nameOfStudent = name;
            iD += 1;
            _id = iD;
            _group = group;
        }

        public Student(Student otherStudent)
        {
            _nameOfStudent = otherStudent._nameOfStudent;
            _id = otherStudent._id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _nameOfStudent;
        }

        public Group GetGroup()
        {
            return _group;
        }
    }
}
