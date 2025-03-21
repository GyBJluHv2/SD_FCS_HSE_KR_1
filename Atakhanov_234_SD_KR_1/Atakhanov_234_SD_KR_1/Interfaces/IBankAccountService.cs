using Domain;

namespace Interfaces
{
    public interface IBankAccountService
    {
        BankAccount CreateBankAccount(int id, string name, decimal initialBalance);
        BankAccount GetBankAccountById(int id);
        void DeleteBankAccount(int id);
        void UpdateBalance(int accountId, decimal amount);
        List<BankAccount> GetAllAccounts();
    }
}