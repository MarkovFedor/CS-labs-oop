using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Exceptions
{
    public class IncorrectGroupNameException : Exception
    {
        public IncorrectGroupNameException(string message)
            : base(message)
        {
        }
    }
}
