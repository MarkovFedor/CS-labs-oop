using System.Collections.Generic;
using Banks.Accounts;
using Banks.Clients;

namespace Banks.Entities
{
    public class AccountStorage
    {
        private Dictionary<Client, List<Account>> _storage;

        public AccountStorage()
        {
            _storage = new Dictionary<Client, List<Account>>();
        }

        public Dictionary<Client, List<Account>> GetStorage()
        {
            return _storage;
        }

        public void AddClientAccount(Client client, Account account)
        {
           if (_storage.ContainsKey(client))
            {
                _storage[client].Add(account);
            }
           else
            {
                _storage.Add(client, new List<Account>());
                _storage[client].Add(account);
            }
        }
    }
}
