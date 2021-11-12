using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Exceptions
{
    public class NotAllowedCourseException : Exception
    {
        public NotAllowedCourseException(string message)
            : base(message)
        {
        }
    }
}
