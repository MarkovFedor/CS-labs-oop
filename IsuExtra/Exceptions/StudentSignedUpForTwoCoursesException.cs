using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Exceptions
{
    public class StudentSignedUpForTwoCoursesException : Exception
    {
        public StudentSignedUpForTwoCoursesException(string message)
            : base(message)
        {
        }
    }
}
