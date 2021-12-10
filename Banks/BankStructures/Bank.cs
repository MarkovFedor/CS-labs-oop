using System;
using System.Collections.Generic;
using Banks.Accounts;
using Banks.Clients;
using Banks.Entities;
using Banks.Notifications;

namespace Banks.BankStructures
{
    public class Bank
    {
        private static int iD = 0;
        private int _dailyDepositePercent;
        private int _transferLimit;
        private int _commission;
        private string _name;
        private int _creditLimit;
        private int _withdrawLimit;
        private AccountStorage _accounts;
        private int _id;
        public Bank(string name)
        {
            _id = iD++;
            _name = name;
            _accounts = new AccountStorage();
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetCreditLimit(int creditLimit)
        {
            _creditLimit = creditLimit;
        }

        public int GetCreditLimit()
        {
            return _creditLimit;
        }

        public void SetWithdrawLimit(int limit)
        {
            if (limit > 0)
            {
                _withdrawLimit = limit;
            }
        }

        public int GetWithdrawLimit()
        {
            return _withdrawLimit;
        }

        public int GetDailyDepositePercent()
        {
            return _dailyDepositePercent;
        }

        public void SetDailyDepositePercent(int percent)
        {
            _dailyDepositePercent = percent;
        }

        public Account GetAccountById(int id)
        {
            Console.WriteLine(id);
            foreach (KeyValuePair<Client, List<Account>> keyValue in _accounts.GetStorage())
            {
                Console.WriteLine();
                foreach (Account account in keyValue.Value)
                {
                    Console.WriteLine(id);
                    Console.WriteLine(account.GetId());
                    if (account.GetId() == id)
                    {
                        return account;
                    }
                }
            }

            throw new Exception("Несуществующий id");
        }

        public DepositeAccount OpenDepositAccount(Client client, int amount)
        {
            var account = new DepositeAccount(this, client, _dailyDepositePercent, amount);
            _accounts.AddClientAccount(client, account);
            return account;
        }

        public CreditAccount OpenCreditAccount(Client client)
        {
            var account = new CreditAccount(this, client);
            _accounts.AddClientAccount(client, account);
            return account;
        }

        public void SetTransferLimit(int limit)
        {
            if (limit > 0)
            {
                _transferLimit = limit;
            }
        }

        public int GetTransferLimit()
        {
            return _transferLimit;
        }

        public void SetCommission(int commission)
        {
            if (commission > 0)
            {
                _commission = commission;
            }
        }

        public int GetCommission()
        {
            return _commission;
        }

        public DebitAccount OpenDebitAccount(Client client)
        {
            var account = new DebitAccount(this, client);
            _accounts.AddClientAccount(client, account);
            return account;
        }

        public void NotifyAccounts()
        {
            var notification = new BankNotification(_dailyDepositePercent, _transferLimit, _commission, _creditLimit);
            foreach (KeyValuePair<Client, List<Account>> keyValue in _accounts.GetStorage())
            {
                foreach (Account account in keyValue.Value)
                {
                    account.Update(notification);
                }
            }
        }
    }
}
