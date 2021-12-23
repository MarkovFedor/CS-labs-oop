namespace BackupsExtra.CustomLog
{
    public interface ILoggerStrategy
    {
        void Log(string prefix, string message);
        void SetDatePrefix(bool state);
    }
}
