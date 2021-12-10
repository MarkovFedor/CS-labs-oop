using System.Collections.Generic;
namespace Banks.Clients
{
    public class Client
    {
        private static int iD = 0;
        private string _name;
        private string _surname;
        private string _address;
        private string _passport;
        private bool _reliable;
        private int _id;
        private List<string> _notifications;

        public Client()
        {
            _id = iD++;
            _notifications = new List<string>();
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetSurname(string surname)
        {
            _surname = surname;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetPassport()
        {
            return _passport;
        }

        public void SetAddress(string address)
        {
            _address = address;
            DefineStatus();
        }

        public void SetPassport(string passport)
        {
            _passport = passport;
            DefineStatus();
        }

        public bool IsReliable()
        {
            return _reliable;
        }

        public override int GetHashCode()
        {
            return _id;
        }

        public void HandleNotification(string notification)
        {
            _notifications.Add(notification);
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public string Info()
        {
            return $"{_name}," +
                $"{_surname}" +
                $"{_passport}" +
                $"{_address}";
        }

        private void DefineStatus()
        {
            if (_address != null && _passport != null)
            {
                _reliable = true;
            }
            else
            {
                _reliable = false;
            }
        }
    }
}
