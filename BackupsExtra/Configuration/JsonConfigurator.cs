using System.IO;
using Backups.Entities;
using BackupsExtra.Exceptions;
using Newtonsoft.Json;
namespace BackupsExtra.Configuration
{
    public class JsonConfigurator
        : IConfigurator
    {
        private string _configFileName;
        private BackupJob _state;

        public JsonConfigurator(string fileName)
        {
            if (IsCorrectFileName(fileName))
            {
                _configFileName = fileName;
            }

            throw new IncorrectFileNameException("Файл конфигурации должен иметь расширение .json");
        }

        public void ImportConfiguration()
        {
            using (var r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                BackupJob backupJob = JsonConvert.DeserializeObject<BackupJob>(json);
                _state = backupJob;
            }
        }

        public void ExportConfiguration()
        {

        }

        public BackupJob GetConfiguration()
        {
            return _state;
        }

        private bool IsCorrectFileName(string fileName)
        {
            string[] fileLexes = fileName.Split('.');
            if (fileLexes[fileLexes.Length - 1] == "json")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
