using Domain;
using Interfaces;
using Patterns.Command;
using Patterns.Decorator;
using Patterns.Facade;
using Patterns.Factory;
using Patterns.TemplateMethod;
using Patterns.Visitor;
using Proxy;
using Repository;
using Services;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Репозитории
            var bankAccountRepository = new BankAccountRepository();
            var categoryRepository = new CategoryRepository();
            var operationRepository = new OperationRepository();

            // Прокси для BankAccountRepository (пример)
            var bankAccountRepositoryProxy = new BankAccountRepositoryProxy(bankAccountRepository);

            // Сервисы
            IBankAccountService bankAccountService = new BankAccountService(bankAccountRepositoryProxy);
            ICategoryService categoryService = new CategoryService(categoryRepository);
            IOperationService operationService = new OperationService(operationRepository, bankAccountRepositoryProxy);

            // Фасад
            var facade = new FinanceFacade(bankAccountService, categoryService, operationService);

            // ====== Пример использования Фабрики ======
            var newAccount = DomainFactory.CreateBankAccount(1, "Main Account", 1000m);
            bankAccountRepository.Add(newAccount);

            var newCategory = DomainFactory.CreateCategory(1, CategoryType.Expense, "Cafe");
            categoryRepository.Add(newCategory);

            // ====== Пример использования Фасада ======
            // Создаём счёт через фасад
            facade.CreateBankAccount(2, "Savings", 2000m);

            // Создаём категорию через фасад
            facade.CreateCategory(2, CategoryType.Income, "Salary");

            // Добавляем операцию через фасад
            var operation = facade.AddOperation(
                id: 1,
                type: CategoryType.Expense,
                bankAccountId: 1,
                amount: 100.5m,
                date: DateTime.Now,
                description: "Starbucks Coffee",
                categoryId: 1
            );

            // ====== Пример использования Команды + Декоратора ======
            var addOpCommand = new AddOperationCommand(
                operationService,
                id: 2,
                type: CategoryType.Income,
                bankAccountId: 1,
                amount: 500m,
                date: DateTime.Now,
                description: "Part-time job",
                categoryId: 2
            );

            // Декоратор для измерения времени исполнения команды
            var timedCommand = new TimingDecorator(addOpCommand);
            timedCommand.Execute();

            // ====== Пример использования Шаблонного метода (импорт CSV / JSON / YAML) ======
            // Допустим, у нас есть файл "operations.csv"
            // CsvDataImporter csvImporter = new CsvDataImporter(bankAccountService, categoryService, operationService);
            // csvImporter.ImportData("operations.csv");

            // ====== Пример использования Посетителя (экспорт) ======
            var visitor = new ExportVisitor();
            // Обходим все счета
            foreach (var acc in bankAccountService.GetAllAccounts())
            {
                visitor.Visit(acc);
            }
            // Все категории
            foreach (var cat in categoryService.GetAllCategories())
            {
                visitor.Visit(cat);
            }
            // Все операции
            foreach (var op in operationService.GetAllOperations())
            {
                visitor.Visit(op);
            }

            // Отформатированный вывод с разделителями и валютой
            Console.WriteLine("\n--- ExportVisitor result (CSV-like) ---");
            Console.WriteLine("===== Bank Accounts =====");
            foreach (var account in bankAccountService.GetAllAccounts())
            {
                Console.WriteLine($"Bank Account ID: {account.Id} | Name: {account.Name} | Balance: {account.Balance:C}");
            }

            Console.WriteLine("\n===== Categories =====");
            foreach (var category in categoryService.GetAllCategories())
            {
                Console.WriteLine($"Category ID: {category.Id} | Type: {category.Type} | Name: {category.Name}");
            }

            Console.WriteLine("\n===== Operations =====");
            // Вместо использования переменной 'operation', используем уникальные имена.
            foreach (var op in operationService.GetAllOperations())
            {
                Console.WriteLine($"Operation ID: {op.Id} | Type: {op.Type} | Account ID: {op.BankAccountId} | Amount: {op.Amount:C} | Date: {op.Date} | Description: {op.Description} | Category ID: {op.CategoryId}");
            }

            Console.WriteLine("\n===== Final Balance =====");
            decimal finalBalance = operationService.CalculateBalanceForAccount(1);
            Console.WriteLine($"Final Balance (Account ID 1): {finalBalance:C}\n");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}