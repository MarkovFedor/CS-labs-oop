using Banks.Clients;
namespace Banks.Transactions
{
    public interface ITransactionStrategy
    {
        void Execute();
        Client GetAuthor();
    }
}
