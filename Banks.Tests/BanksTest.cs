using System;
using NUnit.Framework;
using Banks.BankStructures;
using Banks.Clients;
using Banks.Accounts;
using Banks.Transactions;

namespace Banks.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Replaineshment()
        {
            CentralBank _centralBank = new CentralBank();
            Bank tinkoff = _centralBank.CreateBank("Tinkoff");
            Bank sberbank = _centralBank.CreateBank("Sberbank");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);

            sberbank.SetCommission(10);
            sberbank.SetCreditLimit(5000);
            sberbank.SetDailyDepositePercent(5);
            sberbank.SetTransferLimit(1000);
            sberbank.SetWithdrawLimit(1000);

            Client Alex = _centralBank.RegisterClient("Alex", "Milkovich");
            Client Fedor = _centralBank.RegisterClient("Fedor", "Markov");

            DebitAccount alexAccount = tinkoff.OpenDebitAccount(Alex);
            var fedorAccount = sberbank.OpenDebitAccount(Fedor);

            _centralBank.DoTransaction(new Replenishment(10000, Alex, tinkoff, alexAccount.GetId()));
            _centralBank.DoTransaction(new Replenishment(5000, Fedor, sberbank, fedorAccount.GetId()));
            Assert.AreEqual(10000, alexAccount.GetAmount());
            Assert.AreEqual(5000, fedorAccount.GetAmount());
        }

        [Test]
        public void TryToWithdrawByDoubtfulClient()
        {
            CentralBank _centralBank = new CentralBank();
            Bank tinkoff = _centralBank.CreateBank("Tinkoff");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);

            Client Alex = _centralBank.RegisterClient("Alex", "Milkovich");

            DebitAccount alexAccount = tinkoff.OpenDebitAccount(Alex);

            _centralBank.DoTransaction(new Replenishment(10000, Alex, tinkoff, alexAccount.GetId()));
            Assert.Catch<Exception>(() =>
            {
                _centralBank.DoTransaction(new Withdraw(Alex, 2000, tinkoff, alexAccount.GetId()));
            });
        }
        [Test]
        public void TryToWithdrawByReliableClient()
        {
            CentralBank _centralBank = new CentralBank();
            Bank tinkoff = _centralBank.CreateBank("Tinkoff");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);

            Client Alex = _centralBank.RegisterClient("Alex", "Milkovich", "9348938", "Pomoyka");

            DebitAccount alexAccount = tinkoff.OpenDebitAccount(Alex);

            _centralBank.DoTransaction(new Replenishment(10000, Alex, tinkoff, alexAccount.GetId()));
            _centralBank.DoTransaction(new Withdraw(Alex, 2000, tinkoff, alexAccount.GetId()));

            Assert.AreEqual(8000, alexAccount.GetAmount());
        }
    }
}
