using System;

namespace BackupsExtra.Exceptions
{
    public class IncorrectFileNameException
        : Exception
    {
        public IncorrectFileNameException(string message)
            : base(message)
        { }
    }
}
