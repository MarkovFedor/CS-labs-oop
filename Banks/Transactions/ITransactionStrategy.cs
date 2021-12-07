using Banks.Clients;
namespace Banks.Transactions
{
    public interface ITransactionStrategy
    {
        void Execute();
        string GetInfo();
        Client GetAuthor();
    }
}
