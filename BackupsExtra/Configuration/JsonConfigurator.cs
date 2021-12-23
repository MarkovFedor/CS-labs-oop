using System.Collections.Generic;
using System.IO;
using BackupsExtra.Backup;
using BackupsExtra.Exceptions;
using Newtonsoft.Json;
namespace BackupsExtra.Configuration
{
    public class JsonConfigurator
        : IConfigurator
    {
        private string _configFileName;
        private List<BackupJobExtra> _state;

        public JsonConfigurator(string fileName)
        {
            if (IsCorrectFileName(fileName))
            {
                _configFileName = fileName;
            }

            _state = new List<BackupJobExtra>();

            throw new IncorrectFileNameException("Файл конфигурации должен иметь расширение .json");
        }

        public List<BackupJobExtra> ImportConfiguration()
        {
            using (var r = new StreamReader(_configFileName))
            {
                string json = r.ReadToEnd();
                List<BackupJobExtra> backupJob = JsonConvert.DeserializeObject<List<BackupJobExtra>>(json);
                _state = backupJob;
            }

            return _state;
        }

        public void ExportConfiguration(List<BackupJobExtra> items)
        {
            var serializer = new JsonSerializer();
            using (var r = new StreamWriter(_configFileName))
            using (JsonWriter jw = new JsonTextWriter(r))
            {
                serializer.Serialize(jw, items);
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
