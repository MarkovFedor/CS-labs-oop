using System.Collections.Generic;
using Banks.Clients;

namespace Banks.Notifications
{
    public abstract class IBankPublisher
    {
        private List<Client> _subscribers;

        public IBankPublisher()
        {
            _subscribers = new List<Client>();
        }

        public void Subscribe(Client client)
        {
            if (!_subscribers.Contains(client))
            {
                _subscribers.Add(client);
            }
        }

        public void Unsubscribe(Client client)
        {
            if (_subscribers.Contains(client))
            {
                _subscribers.Remove(client);
            }
        }
    }
}
