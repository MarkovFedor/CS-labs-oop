using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Entity
{
    public class Group
    {
        private static int maxCountOfStudents = 30;
        private string _nameOfGroup;
        private int _numberOfCourse;
        private int _numberOfGroup;
        private List<Student> _students;
        public Group(string name)
        {
            int guessNumberOfCourse = int.Parse(name[2].ToString());
            if (name[0] == 'M' &&
                name[1] == '3' &&
                guessNumberOfCourse > 0 &&
                guessNumberOfCourse < 5 &&
                name.Length == 5)
            {
                _nameOfGroup = name;
                _numberOfCourse = guessNumberOfCourse;
                _numberOfGroup = int.Parse(name.Substring(3, 2));
                _students = new List<Student>();
            }
            else
            {
                throw new IsuException("Некорректное имя группы");
            }
        }

        public Student PutStudent(string name, Group group)
        {
            Student student = new Student(name, group);
            if (_students.Count <= maxCountOfStudents)
            {
                    _students.Add(student);
                    Console.WriteLine(_students.Count.ToString(), maxCountOfStudents);
                    return student;
            }
            else
            {
                throw new IsuException("Достигнуто максимальное количество студентов в группе");
            }
        }

        public void PutStudent(Student student)
        {
            if (_students.Count <= maxCountOfStudents)
            {
                _students.Add(student);
                Console.WriteLine(_students.Count.ToString(), maxCountOfStudents);
            }
            else
            {
                throw new IsuException("Достигнуто максимальное количество студентов в группе");
            }
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public string GetGroupName()
        {
            return _nameOfGroup;
        }

        public int GetNumberOfCourse()
        {
            return _numberOfCourse;
        }
    }
}
