using System.Collections.Generic;
using Banks.Entities;
namespace Banks.Clients
{
    public class Client
    {
        private static int iD = 0;
        private string _name;
        private string _surname;
        private string _address;
        private string _passport;
        private int _id;
        private ClientStatus _status;
        private List<string> _notifications;

        public Client(string name, string surname, string address = null, string passport = null)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _id = iD++;
            _notifications = new List<string>();
            DefineStatus();
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

        public ClientStatus GetStatus()
        {
            return _status;
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
                $"{_address}" +
                $"{_status}";
        }

        private void DefineStatus()
        {
            if (_address != null && _passport != null)
            {
                _status = ClientStatus.RELIABLE;
            }
            else
            {
                _status = ClientStatus.DOUBTFUL;
            }
        }
    }
}
