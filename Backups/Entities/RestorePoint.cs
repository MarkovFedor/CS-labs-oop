using System;
using Backups.Algorithms;
namespace Backups.Entities
{
    public class RestorePoint
    {
        private static int iD = 0;
        private string _path;
        private string _name;
        private string _dirName;
        private DateTime _date;
        private Storage _storage;
        private int _id;
        private IAlgorithm _algorithm;
        public RestorePoint(string name, string path, Storage storage, IAlgorithm algorithm)
        {
            _name = name;
            _path = path;
            _dirName = path + "/" + name;
            _storage = storage;
            _date = DateTime.Now;
            _id = iD++;
            _algorithm = algorithm;
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

        public override int GetHashCode()
        {
            return _id;
        }

        public bool Equals(RestorePoint other)
        {
            return other.GetHashCode() == GetHashCode();
        }

        public IAlgorithm GetAlgorithm()
        {
            return _algorithm;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RestorePoint);
        }

        public string Info()
        {
            return ToString();
        }
    }
}
