using System;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Notifications;
namespace Banks.Accounts
{
    public class DebitAccount
        : Account
    {
        private int _amount;

        public DebitAccount(Bank bank, Client owner)
            : base(bank, owner)
        {
        }

        public override void WithdrawCommission()
        {
            return;
        }

        public int GetAmount()
        {
            return _amount;
        }

        public override void RaisePercents()
        {
            return;
        }

        public void Update()
        {
            return;
        }

        public override void Update(BankNotification notification)
        {
            return;
        }

        public override void Raise(int amount)
        {
            if (amount > 0)
            {
                _amount += amount;
            }
            else
            {
                throw new Exception("Некорректная сумма");
            }
        }

        public override void Withdraw(int amount)
        {
            if (amount > 0 && _amount - amount >= 0)
            {
                if (GetOwner().GetStatus() == Entities.ClientStatus.DOUBTFUL && amount > GetBank().GetWithdrawLimit())
                {
                    throw new Exception("Неподтвержденный клиент списывает слишком много");
                }

                _amount -= amount;
                return;
            }

            throw new Exception("Невозможная транзакция");
        }
    }
}
