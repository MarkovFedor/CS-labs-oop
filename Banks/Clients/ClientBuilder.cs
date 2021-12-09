using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Clients
{
    public class ClientBuilder
        : IBuilder
    {
        private Client _client;

        public ClientBuilder()
        {
            Create();
        }

        public IBuilder SetClient(Client client)
        {
            _client = client;
            return this;
        }

        public IBuilder Create()
        {
            _client = new Client();
            return this;
        }

        public IBuilder AddName(string name)
        {
            _client.SetName(name);
            return this;
        }

        public IBuilder AddSurname(string surname)
        {
            _client.SetSurname(surname);
            return this;
        }

        public IBuilder AddAddress(string address)
        {
            _client.SetAddress(address);
            return this;
        }

        public IBuilder AddPassport(string passport)
        {
            _client.SetPassport(passport);
            return this;
        }

        public Client Build()
        {
            Client result = _client;
            Create();

            return result;
        }
    }
}
