using System;
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
            var builder = new ClientBuilder();
            Client fedor = builder
                .AddName("Fedor")
                .AddSurname("Markov")
                .Build();

            Console.WriteLine(fedor.GetName());
        }
    }
}
