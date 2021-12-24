using System;
using System.IO;
using BackupsExtra.Exceptions;
namespace BackupsExtra.CustomLog
{
    public class FileLoggerStrategy
        : ILoggerStrategy
    {
        private string _logFilePath;
        private bool _datePrefix;
        public FileLoggerStrategy()
        {
        }

        public void SetLogFile(string file)
        {
            _logFilePath = file;
        }

        public void Log(string prefix, string message)
        {
            if (_logFilePath == null) throw new UnsupportLoggingTypeException("Файл для логирования не выбран");
            if (!File.Exists(_logFilePath)) throw new NotLogFileException("Такого файла нет");
            string fullMessage = CreateFullMessage(prefix, message);
            File.AppendAllText(_logFilePath, fullMessage);
        }

        public void SetDatePrefix(bool state)
        {
            _datePrefix = state;
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
