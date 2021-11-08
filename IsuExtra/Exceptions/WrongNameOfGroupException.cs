using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Exceptions
{
    public class WrongNameOfGroupException : Exception
    {
        public WrongNameOfGroupException(string message)
            : base(message)
        {
        }
    }
}
