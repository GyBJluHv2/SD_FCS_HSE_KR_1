using Domain;
using Repository;

namespace Proxy
{
    /// <summary>
    /// Пример прокси, который может кэшировать данные в памяти,
    /// а при необходимости ходить в реальный репозиторий.
    /// </summary>
    public class BankAccountRepositoryProxy : IBankAccountRepository
    {
        private readonly IBankAccountRepository _realRepository;
        private readonly Dictionary<int, BankAccount> _cache = new Dictionary<int, BankAccount>();
        private bool _isCacheLoaded = false;

        public BankAccountRepositoryProxy(IBankAccountRepository realRepository)
        {
            _realRepository = realRepository;
        }

        public void Add(BankAccount account)
        {
            _realRepository.Add(account);
            _cache[account.Id] = account;
        }

        public BankAccount GetById(int id)
        {
            if (_cache.ContainsKey(id))
            {
                return _cache[id];
            }

            var account = _realRepository.GetById(id);
            if (account != null)
            {
                _cache[id] = account;
            }

            return account;
        }

        public void Delete(int id)
        {
            _realRepository.Delete(id);
            if (_cache.ContainsKey(id))
                _cache.Remove(id);
        }

        public List<BankAccount> GetAll()
        {
            if (!_isCacheLoaded)
            {
                var allAccounts = _realRepository.GetAll();
                _cache.Clear();
                foreach (var account in allAccounts)
                {
                    _cache[account.Id] = account;
                }
                _isCacheLoaded = true;
            }
            return _cache.Values.ToList();
        }
    }
}