using System;
using System.Collections.Generic;
using System.IO;
using Backups.Algorithms;
using Backups.Repository;

namespace Backups.Entities
{
    public class BackupJob : IBackupJob
    {
        private string _dir;
        private Storage _storage;
        private IRepository _repository;
        private List<RestorePoint> _restorePoints;
        private IAlgorithm _algorithm;
        private DateTime _date;

        public BackupJob()
        {
            _date = DateTime.Now;
            _storage = new Storage();
            _restorePoints = new List<RestorePoint>();
        }

        public void SetDir(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            _dir = dir;
        }

        public void AddJobObject(string path)
        {
            _storage.AddJobObject(path);
        }

        public void RemoveJobObject(string path)
        {
            _storage.RemoveJobObject(path);
        }

        public List<RestorePoint> GetRestorePoints()
        {
            return _restorePoints;
        }

        public void SetAlgorithm(IAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public string GetDir()
        {
            return _dir;
        }

        public List<string> GetJobObjects()
        {
            return _storage.GetJobObjects();
        }

        public Storage GetStorage()
        {
            return _storage;
        }

        public IAlgorithm GetAlgorithm()
        {
            return _algorithm;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public void SetRepository(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateRestorePoint(string name)
        {
            var restorePoint = new RestorePoint(name, _dir, _storage, _algorithm);
            _algorithm.Save(restorePoint);
            _restorePoints.Add(restorePoint);
        }
    }
}
