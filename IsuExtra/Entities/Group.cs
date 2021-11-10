﻿using System;
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
        public Group(string name)
        {
            _name = name;
            _students = new List<Student>();
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
    }
}