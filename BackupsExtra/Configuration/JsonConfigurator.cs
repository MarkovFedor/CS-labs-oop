using System.Collections.Generic;
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
        private List<BackupJob> _state;

        public JsonConfigurator(string fileName)
        {
            if (IsCorrectFileName(fileName))
            {
                _configFileName = fileName;
            }

            _state = new List<BackupJob>();

            throw new IncorrectFileNameException("Файл конфигурации должен иметь расширение .json");
        }

        public List<BackupJob> ImportConfiguration()
        {
            using (var r = new StreamReader(_configFileName))
            {
                string json = r.ReadToEnd();
                List<BackupJob> backupJob = JsonConvert.DeserializeObject<List<BackupJob>>(json);
                _state = backupJob;
            }

            return _state;
        }

        public void ExportConfiguration(List<BackupJob> items)
        {
            using (var r = new StreamReader(_configFileName))
            {
                JsonSerializer.Serialize<List<BackupJob>>(items);
                _state = backupJob;
            }
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
