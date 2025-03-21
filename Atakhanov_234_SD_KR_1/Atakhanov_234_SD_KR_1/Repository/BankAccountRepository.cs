using Domain;

namespace Repository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly List<BankAccount> _bankAccounts = new List<BankAccount>();

        public void Add(BankAccount account)
        {
            _bankAccounts.Add(account);
        }

        public BankAccount GetById(int id)
        {
            return _bankAccounts.FirstOrDefault(a => a.Id == id);
        }

        public void Delete(int id)
        {
            var account = GetById(id);
            if (account != null)
            {
                _bankAccounts.Remove(account);
            }
        }

        public List<BankAccount> GetAll()
        {
            return _bankAccounts;
        }
    }
}