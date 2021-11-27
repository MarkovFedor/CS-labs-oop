using System;
using System.Collections.Generic;
using System.Text;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Entities;

namespace Banks.Account
{
    public class DepositeAccount
        : IAccount
    {
        private Bank _bank;
        private Client _owner;
        private int _amount;

        public DepositeAccount(Bank bank, Client owner)
        {
            _bank = bank;
            _owner = owner;
        }

        public Bank GetBank()
        {
            return _bank;
        }

        public Client GetOwner()
        {
            return _owner;
        }

        public void Raise(int amount)
        {
            if (IsCorrectAmount(amount))
            {
                _amount += amount;
            }
        }

        public void Withdraw(int amount)
        {
            if (IsCorrectAmount(amount) && amount <= _amount)
            {
                switch (_owner.GetStatus())
                {
                    case ClientStatus.DOUBTFUL:
                        if (amount > _bank.GetWithdrawLimit())
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

        public void RaiseDailyPercents()
        {
            int percent = _bank.GetDailyDepositePercent();
            _amount += _amount * percent;
        }

        private bool IsCorrectAmount(int amount)
        {
            return amount > 0;
        }
    }
}
