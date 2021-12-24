using System;
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
