using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Exceptions;

namespace IsuExtra.Entities
{
    public class Student : Isu.Entity.Student
    {
        private OGNPCourse firstCourse;
        private OGNPCourse secondCourse;
        private Megafaculty _megafaculty;
        private Group _group;

        public Student(string name, Group group, Megafaculty megafaculty)
            : base(name, group)
        {
            _megafaculty = megafaculty;
            _group = group;
        }

        public OGNPCourse GetFirstCourse()
        {
            return firstCourse;
        }

        public OGNPCourse GetSecondCourse()
        {
            return secondCourse;
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

        public Group GetModifiedGroup()
        {
            return _group;
        }
    }
}
