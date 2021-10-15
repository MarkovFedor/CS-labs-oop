using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Exceptions
{
    public class ShopException : Exception
    {
        public ShopException(string message)
            : base(message) { }
    }
}
