using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Exceptions;

namespace IsuExtra.Entities
{
    public class Student
    {
        private static int iD = 0;
        private int _id;
        private string _name;
        private Group _group;
        private OGNPCourse firstCourse;
        private OGNPCourse secondCourse;
        private Megafaculty _megafaculty;

        public Student(string name, Group group, Megafaculty megafaculty)
        {
            _name = name;
            _group = group;
            _megafaculty = megafaculty;
            _id = iD++;
        }

        public string GetName()
        {
            return _name;
        }

        public OGNPCourse GetFirstCourse()
        {
            return firstCourse;
        }

        public OGNPCourse GetSecondCourse()
        {
            return secondCourse;
        }

        public Group GetGroup()
        {
            return _group;
        }

        public void SignUpForCourse(OGNPCourse course)
        {
            if (_group.GetMegafaculty().GetID() == course.GetMegafaculty().GetID())
            {
                throw new NotAllowedCourseException("Попытка записать студента на курс, факультету которого он уже принадлежит");
            }

            if (firstCourse == null)
            {
                if (course.SubscribeStudent(this))
                {
                    firstCourse = course;
                }

                return;
            }

            if (secondCourse == null)
            {
                if (course.SubscribeStudent(this))
                {
                    firstCourse = course;
                }

                return;
            }

            throw new StudentSignedUpForTwoCoursesException("Студент записан на 2 курса");
        }

        public void SignOutFromCourse(OGNPCourse course)
        {
            if (course == firstCourse)
            {
                firstCourse = null;
            }

            if (course == secondCourse)
            {
                secondCourse = null;
            }

            course.SignOutStudent(this);
        }

        public Megafaculty GetMegafaculty()
        {
            return _megafaculty;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Student);
        }

        public bool Equals(Student student)
        {
            return GetHashCode() == student.GetHashCode();
        }

        public override int GetHashCode()
        {
            return _id;
        }
    }
}
