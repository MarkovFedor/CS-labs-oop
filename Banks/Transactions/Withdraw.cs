using System;
using Banks.Accounts;
using Banks.BankStructures;
using Banks.Clients;
namespace Banks.Transactions
{
    public class Withdraw
        : ITransactionStrategy
    {
        private Client _author;
        private int _amount;
        private Bank _bank;
        private int _idOfAccount;
        private TransactionStatus _status;

        public Withdraw(Client author, int amount, Bank bank, int id)
        {
            _author = author;
            _amount = amount;
            _bank = bank;
            _idOfAccount = id;
            _status = TransactionStatus.FAIL;
        }

        public string GetInfo()
        {
            return $"WITHDRAW TRANSACTION: by {_author}, amount: {_amount}, bank: {_bank}, account: {_idOfAccount}, status: {_status}";
        }

        public void Execute()
        {
            Account account = _bank.GetAccountById(_idOfAccount);
            if (account.GetOwner().Equals(_author))
            {
                Console.WriteLine(_author.GetId());
                account.Withdraw(_amount);
                _status = TransactionStatus.SUCCESS;
                return;
            }

            throw new Exception("Транзакция невозможна");
        }

        public Client GetAuthor()
        {
            return _author;
        }
    }
}
