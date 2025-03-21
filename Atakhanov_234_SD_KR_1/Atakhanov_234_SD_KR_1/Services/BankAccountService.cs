using Domain;
using Interfaces;
using Repository;

namespace Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public BankAccount CreateBankAccount(int id, string name, decimal initialBalance)
        {
            var account = new BankAccount(id, name, initialBalance);
            _bankAccountRepository.Add(account);
            return account;
        }

        public BankAccount GetBankAccountById(int id)
        {
            return _bankAccountRepository.GetById(id);
        }

        public void DeleteBankAccount(int id)
        {
            _bankAccountRepository.Delete(id);
        }

        public void UpdateBalance(int accountId, decimal amount)
        {
            var account = _bankAccountRepository.GetById(accountId);
            if (account != null)
            {
                account.UpdateBalance(amount);
            }
        }

        public List<BankAccount> GetAllAccounts()
        {
            return _bankAccountRepository.GetAll();
        }
    }
}