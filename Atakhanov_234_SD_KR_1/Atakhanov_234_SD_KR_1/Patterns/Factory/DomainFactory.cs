using Domain;

namespace Patterns.Factory
{
    /// <summary>
    /// Фабрика для создания доменных объектов (с валидацией и т.д.).
    /// </summary>
    public static class DomainFactory
    {
        public static BankAccount CreateBankAccount(int id, string name, decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            return new BankAccount(id, name, initialBalance);
        }

        public static Category CreateCategory(int id, CategoryType type, string name)
        {
            // Можно добавить любую другую бизнес-валидацию
            return new Category(id, type, name);
        }

        public static Operation CreateOperation(int id, CategoryType type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            if (amount < 0)
                throw new ArgumentException("Operation amount cannot be negative.");

            return new Operation(id, type, bankAccountId, amount, date, description, categoryId);
        }
    }
}