using System;
using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Entity
{
    public class Group
    {
        private const int MaxCountOfStudents = 30;
        private const char FirstLetterOfGroup = 'M';
        private const char NumberOfFaculty = '3';
        private const int MinimalCourseNumber = 1;
        private const int MaxCourseNumber = 4;
        private const int LengthOfGroupName = 5;

        private string _nameOfGroup;
        private int _numberOfCourse;
        private int _numberOfGroup;
        private List<Student> _students;
        public Group(string name)
        {
            int guessNumberOfCourse = int.Parse(name[2].ToString());
            if (name[0] == FirstLetterOfGroup &&
                name[1] == NumberOfFaculty &&
                guessNumberOfCourse >= MinimalCourseNumber &&
                guessNumberOfCourse <= MaxCourseNumber &&
                name.Length == LengthOfGroupName)
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
            if (_students.Count < MaxCountOfStudents)
            {
                Student student = new Student(name, group);
                _students.Add(student);
                return student;
            }
            else
            {
                throw new IsuException("Достигнуто максимальное количество студентов в группе");
            }
        }

        public void PutStudent(Student student)
        {
            if (_students.Count <= MaxCountOfStudents)
            {
                _students.Add(student);
                Console.WriteLine(_students.Count.ToString(), MaxCountOfStudents);
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
