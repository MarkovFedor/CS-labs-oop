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
        private CentralBank _centralBank;
        private ClientBuilder _clientBuilder;
        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
            _clientBuilder = new ClientBuilder();
        }

        [Test]
        public void Replaineshment()
        {
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
            Client Alex = _clientBuilder
                .AddName("Alex")
                .AddSurname("Milkovich")
                .Build();
            Client Fedor = _clientBuilder
                .AddName("Fedor")
                .AddSurname("Markov")
                .Build();
            _centralBank.RegisterClient(Alex);
            _centralBank.RegisterClient(Fedor);

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
            Bank tinkoff = _centralBank.CreateBank("Tinkoff");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);
            Client Alex = _clientBuilder
                .AddName("Alex")
                .AddSurname("Milkovich")
                .Build();
            _centralBank.RegisterClient(Alex);

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
            Bank tinkoff = _centralBank.CreateBank("Tinkoff");

            tinkoff.SetCommission(10);
            tinkoff.SetCreditLimit(5000);
            tinkoff.SetDailyDepositePercent(5);
            tinkoff.SetTransferLimit(1000);
            tinkoff.SetWithdrawLimit(1000);
            Client Alex = _clientBuilder
                .AddName("Alex")
                .AddSurname("Milkovich")
                .AddPassport("8-800-555-35-35")
                .AddAddress("Pomoyka 228")
                .Build();

            DebitAccount alexAccount = tinkoff.OpenDebitAccount(Alex);

            _centralBank.DoTransaction(new Replenishment(10000, Alex, tinkoff, alexAccount.GetId()));
            _centralBank.DoTransaction(new Withdraw(Alex, 2000, tinkoff, alexAccount.GetId()));

            Assert.AreEqual(8000, alexAccount.GetAmount());
        }
    }
}
