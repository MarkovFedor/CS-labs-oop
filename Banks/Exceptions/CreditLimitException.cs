using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Exceptions
{
    public class CreditLimitException
        : Exception
    {
        public CreditLimitException(string message)
            : base(message)
        {
        }
    }
}
