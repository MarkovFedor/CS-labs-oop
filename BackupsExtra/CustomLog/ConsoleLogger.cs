using System;
namespace BackupsExtra.CustomLog
{
    public class ConsoleLogger
        : ILoggerStrategy
    {
        private bool _datePrefix;
        public ConsoleLogger()
        {
        }

        public void SetDatePrefix(bool state)
        {
            _datePrefix = state;
        }

        public void Log(string prefix, string message)
        {
            Console.WriteLine(CreateFullMessage(prefix, message));
        }

        private string CreateFullMessage(string prefix, string message)
        {
            string fullMessage = " ";
            if (_datePrefix)
            {
                fullMessage = $"{DateTime.Now} : {prefix} : {message} .";
            }

            return fullMessage;
        }
    }
}
