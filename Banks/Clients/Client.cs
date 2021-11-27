using Banks.Entities;

namespace Banks.Clients
{
    public class Client
    {
        private string _name;
        private string _surname;
        private string _address;
        private string _passport;
        private ClientStatus _status;

        private Client(string name, string surname, string address = null, string passport = null)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            DefineStatus();
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
