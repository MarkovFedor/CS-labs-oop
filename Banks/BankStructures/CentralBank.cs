using System.Collections.Generic;
using Banks.Clients;
using Banks.Transactions;
namespace Banks.BankStructures
{
    public class CentralBank
    {
        private List<ITransactionStrategy> _transactionsHistory;
        private List<Bank> _banks;
        private List<Client> _registratedClients;
        public CentralBank()
        {
            _transactionsHistory = new List<ITransactionStrategy>();
            _registratedClients = new List<Client>();
            _banks = new List<Bank>();
        }

        public Bank CreateBank(string name)
        {
            var bank = new Bank(name);
            _banks.Add(bank);
            return bank;
        }

        public void DoTransaction(ITransactionStrategy transaction)
        {
            _transactionsHistory.Add(transaction);
            transaction.Execute();
            transaction.GetAuthor().HandleNotification(transaction.GetInfo());
        }

        public List<Client> GetRegistratedClients()
        {
            return _registratedClients;
        }

        public Client RegisterClient(string name, string surname, string passport = null, string address = null)
        {
            var client = new Client(name, surname, passport, address);
            _registratedClients.Add(client);
            return client;
        }

        public Client FindClient(string name, string surname)
        {
            foreach (Client client in _registratedClients)
            {
                if (client.GetName() == name && client.GetSurname() == surname)
                {
                    return client;
                }
            }

            throw new System.Exception("Нет такого клиента");
        }

        public Bank FindBank(string name)
        {
            foreach (Bank bank in _banks)
            {
                if (bank.GetName() == name)
                {
                    return bank;
                }
            }

            throw new System.Exception("Нет такого банка");
        }
    }
}
