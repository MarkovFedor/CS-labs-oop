using System;
using System.Collections.Generic;
using System.Text;

namespace IsuExtra.Entities
{
    public class Lesson
    {
        private DateTime _startOfLesson;
        private DateTime _endOfLesson;
        private string _name;

        public Lesson(DateTime start, DateTime end, string name)
        {
            _startOfLesson = start;
            _endOfLesson = end;
            _name = name;
        }

        public DateTime GetStart()
        {
            return _startOfLesson;
        }

        public DateTime GetEnd()
        {
            return _endOfLesson;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
