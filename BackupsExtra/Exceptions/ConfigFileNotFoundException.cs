using System;

namespace BackupsExtra.Exceptions
{
    public class ConfigFileNotFoundException
        : Exception
    {
        public ConfigFileNotFoundException(string message)
            : base(message)
        {
        }
    }
}
