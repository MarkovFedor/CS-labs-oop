﻿using System;
using System.Collections.Generic;
using System.Text;
using IsuExtra.Exceptions;

namespace IsuExtra.Entities
{
    public class Student
    {
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
                firstCourse = course;
                course.SubscribeStudent(this);
                return;
            }

            if (secondCourse == null)
            {
                secondCourse = course;
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
    }
}