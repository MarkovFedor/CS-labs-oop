using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Entities
{
    public class Storage
    {
        private List<string> _jobObjects;
        public Storage()
        {
            _jobObjects = new List<string>();
        }

        public void AddJobObject(string file)
        {
            _jobObjects.Add(file);
        }

        public void RemoveJobObject(string file)
        {
            _jobObjects.Remove(file);
        }

        public List<string> GetJobObjects()
        {
            return _jobObjects;
        }
    }
}
