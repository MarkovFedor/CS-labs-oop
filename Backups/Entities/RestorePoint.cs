using System;
using System.Collections.Generic;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private string _path;
        private string _name;
        private string _dirName;
        private DateTime _date;
        private List<string> _jobObjects;

        public RestorePoint(string name, string path, List<string> jobObjects)
        {
            _name = name;
            _path = path;
            _dirName = path + "/" + name;
            _jobObjects = jobObjects;
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

        public List<string> GetJobObjects()
        {
            return _jobObjects;
        }

        public string Info()
        {
            return ToString();
        }
    }
}
