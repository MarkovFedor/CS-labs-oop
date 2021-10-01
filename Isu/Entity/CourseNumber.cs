using System;
using Isu.Tools;

namespace Isu.Entity
{
    public class CourseNumber
    {
        private const int MinimalCourseNumber = 0;
        private const int MaximumCourseNumber = 4;

        private int _numberOfCourse;

        public CourseNumber(int course)
        {
            if (course < MinimalCourseNumber || course > MaximumCourseNumber)
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
