using System;
using System.Collections.Generic;
using System.IO;
using Backups.Algorithms;

namespace Backups.Entities
{
    public class BackupJob : IBackupJob
    {
        private string _dir;
        private List<string> _jobObjects;
        private List<RestorePoint> _restorePoints;
        private IAlgorithmRepository _algorithmRepository;
        private DateTime _date;

        public BackupJob()
        {
            _date = DateTime.Now;
            _jobObjects = new List<string>();
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
            _jobObjects.Add(path);
        }

        public void RemoveJobObject(string path)
        {
            _jobObjects.Remove(path);
        }

        public List<RestorePoint> GetRestorePoints()
        {
            return _restorePoints;
        }

        public void SetAlgorithm(IAlgorithmRepository algorithm)
        {
            _algorithmRepository = algorithm;
        }

        public string GetDir()
        {
            return _dir;
        }

        public List<string> GetJobObjects()
        {
            return _jobObjects;
        }

        public IAlgorithmRepository GetAlgorithm()
        {
            return _algorithmRepository;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public void CreateRestorePoint(string name)
        {
            var restorePoint = new RestorePoint(name, _dir, _jobObjects);
            _algorithmRepository.Save(restorePoint);
            _restorePoints.Add(restorePoint);
        }
    }
}
