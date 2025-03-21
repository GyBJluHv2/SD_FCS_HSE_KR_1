using Domain;
using NUnit.Framework;
using Repository;
using Services;

namespace Tests
{
    [TestFixture]
    public class OperationServiceTests
    {
        private OperationRepository _operationRepository;
        private BankAccountRepository _bankAccountRepository;
        private OperationService _operationService;

        [SetUp]
        public void Setup()
        {
            _operationRepository = new OperationRepository();
            _bankAccountRepository = new BankAccountRepository();
            _operationService = new OperationService(_operationRepository, _bankAccountRepository);

            // Подготовим тестовый счёт
            var account = new BankAccount(1, "Test Account", 0m);
            _bankAccountRepository.Add(account);
        }

        [Test]
        public void TestAddIncomeAndExpense()
        {
            // Доход
            _operationService.AddOperation(1, CategoryType.Income, 1, 1000m, DateTime.Now, "Salary", 100);

            // Расход
            _operationService.AddOperation(2, CategoryType.Expense, 1, 250m, DateTime.Now, "Groceries", 101);

            var balance = _operationService.CalculateBalanceForAccount(1);
            Assert.Equals(750m, balance);
        }

        [Test]
        public void TestAddNegativeOperation_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _operationService.AddOperation(3, CategoryType.Expense, 1, -10m, DateTime.Now, "Invalid", 102);
            });
        }
    }
}