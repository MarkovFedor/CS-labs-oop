using System;
using System.Collections.Generic;
using System.Text;

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
