using System;

namespace Isu.Tools
{
    public class IsuException : Exception
    {
        public IsuException()
        {
        }

        public IsuException(string message)
            : base(message)
        {
        }

        public IsuException(string message, IsuException innerIsuException)
            : base(message, innerIsuException)
        {
        }
    }
}