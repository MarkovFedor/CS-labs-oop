using System;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private string _path;
        private string _name;
        private string _dirName;
        private DateTime _date;
        private Storage _storage;

        public RestorePoint(string name, string path, Storage storage)
        {
            _name = name;
            _path = path;
            _dirName = path + "/" + name;
            _storage = storage;
            _date = DateTime.Now;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDirName()
        {
            return _dirName;
        }

        public string GetPath()
        {
            return _path;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public void SetPath(string path)
        {
            _path = path;
        }

        public Storage GetStorage()
        {
            return _storage;
        }

        public string Info()
        {
            return ToString();
        }
    }
}
