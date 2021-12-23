using System.Collections.Generic;
namespace BackupsExtra.CustomLog
{
    public class Logger
    {
        private List<ILoggerStrategy> _loggerStrategies;

        public Logger()
        {
            _loggerStrategies = new List<ILoggerStrategy>();
        }

        public void AddLoggerStrategy(ILoggerStrategy strategy)
        {
            _loggerStrategies.Add(strategy);
        }

        public void Log(string prefix, string message)
        {
            foreach (ILoggerStrategy logger in _loggerStrategies)
            {
                logger.Log(prefix, message);
            }
        }
    }
}
