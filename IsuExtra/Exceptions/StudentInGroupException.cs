using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Exceptions
{
    public class StudentInGroupException : Exception
    {
        public StudentInGroupException(string message)
            : base(message)
        {
        }
    }
}
