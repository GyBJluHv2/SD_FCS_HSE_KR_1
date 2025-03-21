using Domain;
using Interfaces;

namespace Patterns.Facade
{
    /// <summary>
    /// Фасад, упрощающий работу с основными сервисами.
    /// </summary>
    public class FinanceFacade
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ICategoryService _categoryService;
        private readonly IOperationService _operationService;

        public FinanceFacade(
            IBankAccountService bankAccountService,
            ICategoryService categoryService,
            IOperationService operationService)
        {
            _bankAccountService = bankAccountService;
            _categoryService = categoryService;
            _operationService = operationService;
        }

        public BankAccount CreateBankAccount(int id, string name, decimal initialBalance)
        {
            return _bankAccountService.CreateBankAccount(id, name, initialBalance);
        }

        public Category CreateCategory(int id, CategoryType type, string name)
        {
            return _categoryService.CreateCategory(id, type, name);
        }

        public Operation AddOperation(int id, CategoryType type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            return _operationService.AddOperation(id, type, bankAccountId, amount, date, description, categoryId);
        }

        // Можно дополнительно здесь же предоставить методы аналитики, экспорта и т.д.
    }
}