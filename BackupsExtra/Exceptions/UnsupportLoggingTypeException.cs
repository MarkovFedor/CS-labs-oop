using System;
using System.Collections.Generic;
using System.Text;

namespace BackupsExtra.Exceptions
{
    public class UnsupportLoggingTypeException
        : Exception
    {
        public UnsupportLoggingTypeException(string message)
            : base(message)
        {
        }
    }
}
