using Banks.BankStructures;
using Banks.Clients;
using Banks.Notifications;
namespace Banks.Accounts
{
    public abstract class Account
    {
        private static int iD = 0;
        private int _id;
        private Bank _bank;
        private Client _owner;
        public Account(Bank bank, Client owner)
        {
            _id = iD++;
            _bank = bank;
            _owner = owner;
        }

        public int GetId()
        {
            return _id;
        }

        public Bank GetBank()
        {
            return _bank;
        }

        public Client GetOwner()
        {
            return _owner;
        }

        public abstract void WithdrawCommission();
        public abstract void RaisePercents();
        public abstract void Update(BankNotification notification);
        public abstract void Withdraw(int amount);
        public abstract void Raise(int amount);
    }
}
