using System;
using Banks.Accounts;
using Banks.BankStructures;
using Banks.Clients;
namespace Banks.Transactions
{
    public class Transfer
        : ITransactionStrategy
    {
        private Client _author;
        private Bank _withdrawBank;
        private Bank _raiseBank;
        private int _withdrawId;
        private int _raiseId;
        private int _amount;

        public Transfer(Client author, Bank withdrawBank, int withdrawId, Bank raiseBank, int raiseId, int amount)
        {
            _author = author;
            _withdrawBank = withdrawBank;
            _raiseBank = raiseBank;
            _withdrawId = withdrawId;
            _raiseId = raiseId;
            _amount = amount;
            if (amount < 0) throw new Exception("Некорректная сумма перевода");
        }

        public void Execute()
        {
            Account withdrawAccount = _withdrawBank.GetAccountById(_withdrawId);
            Account raiseAccount = _raiseBank.GetAccountById(_raiseId);
            withdrawAccount.Withdraw(_amount);
            raiseAccount.Raise(_amount);
        }

        public Client GetAuthor()
        {
            return _author;
        }
    }
}
