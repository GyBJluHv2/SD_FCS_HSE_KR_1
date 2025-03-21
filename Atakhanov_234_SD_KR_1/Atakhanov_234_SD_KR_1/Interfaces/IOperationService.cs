using Domain;

namespace Interfaces
{
    public interface IOperationService
    {
        Operation AddOperation(int id, CategoryType type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId);
        List<Operation> GetOperationsByAccountId(int bankAccountId);
        List<Operation> GetAllOperations();
        decimal CalculateBalanceForAccount(int bankAccountId);
    }
}