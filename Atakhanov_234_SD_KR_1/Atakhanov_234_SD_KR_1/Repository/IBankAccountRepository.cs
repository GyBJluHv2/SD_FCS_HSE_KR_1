using Domain;

namespace Repository
{
    public interface IBankAccountRepository
    {
        void Add(BankAccount account);
        BankAccount GetById(int id);
        void Delete(int id);
        List<BankAccount> GetAll();
    }
}