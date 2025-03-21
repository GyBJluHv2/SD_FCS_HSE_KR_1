using Domain;
using Interfaces;
using Repository;

namespace Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public OperationService(IOperationRepository operationRepository, IBankAccountRepository bankAccountRepository)
        {
            _operationRepository = operationRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public Operation AddOperation(int id, CategoryType type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            var operation = new Operation(id, type, bankAccountId, amount, date, description, categoryId);
            _operationRepository.Add(operation);

            // Обновляем баланс счёта
            var account = _bankAccountRepository.GetById(bankAccountId);
            if (account != null)
            {
                // Приходная операция -> увеличиваем баланс, расходная -> уменьшаем
                decimal delta = (type == CategoryType.Income) ? amount : -amount;
                account.UpdateBalance(delta);
            }

            return operation;
        }

        public List<Operation> GetOperationsByAccountId(int bankAccountId)
        {
            return _operationRepository
                .GetAll()
                .Where(op => op.BankAccountId == bankAccountId)
                .ToList();
        }

        public List<Operation> GetAllOperations()
        {
            return _operationRepository.GetAll();
        }

        public decimal CalculateBalanceForAccount(int bankAccountId)
        {
            var operations = GetOperationsByAccountId(bankAccountId);
            return operations.Sum(op => op.Type == CategoryType.Income ? op.Amount : -op.Amount);
        }
    }
}