using System;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Notifications;
namespace Banks.Accounts
{
    public class CreditAccount
        : Account
    {
        private int _amount;
        private int _limit;
        private bool _isCommission;
        private int _commission;
        public CreditAccount(Bank bank, Client owner)
            : base(bank, owner)
        {
            _commission = bank.GetCommission();
        }

        public override void Withdraw(int amount)
        {
            if (_amount - amount < _limit)
            {
                throw new Exception("Превышен лимит");
            }
            else
            {
                _amount -= amount;
                CheckCommissionStatus();
            }
        }

        public override void Raise(int amount)
        {
            if (amount > 0)
            {
                _amount += amount;
            }

            CheckCommissionStatus();
        }

        public int GetAmount()
        {
            return _amount;
        }

        public int GetLimit()
        {
            return _limit;
        }

        public bool GetCommissionStatus()
        {
            return _isCommission;
        }

        public int GetCommission()
        {
            return _commission;
        }

        public override void RaisePercents()
        {
            return;
        }

        public override void Update(BankNotification notification)
        {
            _limit = notification.GetCreditLimit();
            WithdrawCommission();
        }

        public override void WithdrawCommission()
        {
            if (_amount < 0)
            {
                _amount -= -_amount * _commission;
            }
        }

        private void CheckCommissionStatus()
        {
            if (_amount > 0)
            {
                _isCommission = false;
            }
            else
            {
                _isCommission = true;
            }
        }
    }
}
