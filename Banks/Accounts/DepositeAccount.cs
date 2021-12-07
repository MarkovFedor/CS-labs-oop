using System;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Entities;
using Banks.Notifications;
namespace Banks.Accounts
{
    public class DepositeAccount
        : Account
    {
        private int _amount;
        private int _percents;
        private int _startAmount;
        private DateTime _endOfDeposite;
        private bool _isEndOfDeposite;
        public DepositeAccount(Bank bank, Client owner, int percents, int startAmount)
            : base(bank, owner)
        {
            _percents = percents;
            _startAmount = startAmount;
            _endOfDeposite = DateTime.Now.AddYears(1);
            DefineIsEndOfDeposite();
        }

        public override void Raise(int amount)
        {
            if (IsCorrectAmount(amount))
            {
                _amount += amount;
            }
        }

        public override void Withdraw(int amount)
        {
            if (IsCorrectAmount(amount) && amount <= _amount && _isEndOfDeposite)
            {
                switch (GetOwner().GetStatus())
                {
                    case ClientStatus.DOUBTFUL:
                        if (amount > GetBank().GetWithdrawLimit())
                        {
                            throw new Exception("Статус запрещает");
                        }
                        else
                        {
                            _amount -= amount;
                        }

                        break;
                    case ClientStatus.RELIABLE:
                        _amount -= amount;
                        break;
                }
            }
        }

        public void DailyUpdate()
        {
            return;
        }

        public void RaiseDailyPercents()
        {
            int percent = GetBank().GetDailyDepositePercent();
            _amount += _amount * percent;
        }

        public override void WithdrawCommission()
        {
            return;
        }

        public override void RaisePercents()
        {
            if (!_isEndOfDeposite)
            {
                _amount += _startAmount * _percents;
            }
        }

        public override void Update(BankNotification notification)
        {
            _percents = notification.GetDailyDepositePercent();
            RaisePercents();
            WithdrawCommission();
        }

        private void DefineIsEndOfDeposite()
        {
            if (_endOfDeposite < DateTime.Now)
            {
                _isEndOfDeposite = true;
            }
            else
            {
                _isEndOfDeposite = false;
            }
        }

        private bool IsCorrectAmount(int amount)
        {
            return amount > 0;
        }
    }
}
