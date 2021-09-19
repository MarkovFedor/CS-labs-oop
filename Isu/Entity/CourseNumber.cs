using System;
using Isu.Tools;

namespace Isu.Entity
{
    public class CourseNumber
    {
        private int _numberOfCourse;

        public CourseNumber(int course)
        {
            if (course < 0 || course > 4)
            {
                throw new IsuException("Такого курса быть не может");
            }
            else
            {
                _numberOfCourse = course;
            }
        }

        public int GetNumberOfCourse()
        {
            return _numberOfCourse;
        }
    }
}
