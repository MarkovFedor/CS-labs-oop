using System;
namespace BackupsExtra.Exceptions
{
    public class AllPointsToCleanException
        : Exception
    {
        public AllPointsToCleanException(string message)
            : base(message)
        {
        }
    }
}
