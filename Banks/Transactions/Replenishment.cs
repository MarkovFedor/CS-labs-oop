using System;
using System.Collections.Generic;
using System.Text;
using Banks.Accounts;
using Banks.BankStructures;
using Banks.Clients;
namespace Banks.Transactions
{
    public class Replenishment
        : ITransactionStrategy
    {
        private int _amount;
        private Client _author;
        private Bank _bank;
        private int _id;

        public Replenishment(int amount, Client author, Bank bank, int id)
        {
            if (amount < 0) throw new Exception("Недопустимая сумма");
            _amount = amount;
            _author = author;
            _bank = bank;
            _id = id;
        }

        public void Execute()
        {
            Account account = _bank.GetAccountById(_id);
            account.Raise(_amount);
        }

        public Client GetAuthor()
        {
            return _author;
        }
    }
}
