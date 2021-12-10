namespace BackupsExtra.Configuration
{
    public interface IConfigurator
    {
        void ImportConfiguration();
        void ExportConfiguration();
    }
}
