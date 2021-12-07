using Banks.Accounts;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Transactions;
namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var centralBank = new CentralBank();
            Bank tinkoff = centralBank.CreateBank("Tinkoff");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);

            Client alex = centralBank.RegisterClient("Alex", "Milkovich", "9348938", "Pomoyka");

            DebitAccount alexAccount = tinkoff.OpenDebitAccount(alex);

            centralBank.DoTransaction(new Replenishment(10000, alex, tinkoff, alexAccount.GetId()));
            centralBank.DoTransaction(new Withdraw(alex, 2000, tinkoff, alexAccount.GetId()));
        }
    }
}
