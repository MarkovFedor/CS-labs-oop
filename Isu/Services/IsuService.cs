using System;
using System.Collections.Generic;
using Isu.Entity;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _groups;

        public IsuService()
        {
            _groups = new List<Group>();
        }

        public Group AddGroup(string name)
        {
            Group addedGroup = new Group(name);
            _groups.Add(addedGroup);
            return addedGroup;
        }

        public Student AddStudent(Group group, string name)
        {
            return group.PutStudent(name, group);
        }

        public Student GetStudent(int id)
        {
            foreach (var group in _groups)
            {
                foreach (var student in group.GetStudents())
                {
                    if (student.GetId() == id)
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("Студента с данным id не существует");
        }

        public Student FindStudent(string name)
        {
            foreach (var group in _groups)
            {
                foreach (var student in group.GetStudents())
                {
                    if (student.GetName().Equals(name))
                    {
                        return student;
                    }
                }
            }

            throw new IsuException("Студента с таким именем не существует");
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (var group in _groups)
            {
                if (group.GetGroupName().Equals(groupName))
                {
                    return group.GetStudents();
                }
            }

            throw new IsuException("Группы с таким именем не существует");
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            List<Student> allGroupsOfCourse = new List<Student>();
            foreach (var group in _groups)
            {
                if (courseNumber.GetNumberOfCourse() == group.GetNumberOfCourse())
                {
                    allGroupsOfCourse.AddRange(group.GetStudents());
                }
            }

            return allGroupsOfCourse;
        }

        public Group FindGroup(string groupName)
        {
            foreach (var group in _groups)
            {
                if (group.GetGroupName().Equals(groupName))
                {
                    return group;
                }
            }

            throw new IsuException("Группы с таким именем не существует");
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            List<Group> allGroupsOfCourse = new List<Group>();
            foreach (var group in _groups)
            {
                if (group.GetNumberOfCourse() == courseNumber.GetNumberOfCourse())
                {
                    allGroupsOfCourse.Add(group);
                }
            }

            return allGroupsOfCourse;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (var group in _groups)
            {
                foreach (var guessStudent in group.GetStudents())
                {
                    if (guessStudent.Equals(student))
                    {
                        if (group.GetStudents().Contains(student))
                        {
                            throw new IsuException("Студент уже в данной группе");
                        }
                        else
                        {
                            group.GetStudents().Remove(student);
                            newGroup.GetStudents().Add(student);
                            return;
                        }
                    }
                }
            }
        }
    }
}
