using System;
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
