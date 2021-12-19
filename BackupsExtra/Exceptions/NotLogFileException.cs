using System;
using System.Collections.Generic;
using System.Text;

namespace BackupsExtra.Exceptions
{
    public class NotLogFileException
        : Exception
    {
        public NotLogFileException(string message)
            : base(message)
        {
        }
    }
}
