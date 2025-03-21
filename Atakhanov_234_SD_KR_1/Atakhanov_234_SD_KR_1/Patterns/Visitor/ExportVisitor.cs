using Domain;
using System.Text;

namespace Patterns.Visitor
{
    /// <summary>
    /// Пример посетителя, который "обходит" объекты и
    /// формирует, например, CSV-выгрузку.
    /// </summary>
    public class ExportVisitor : IVisitor
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public void Visit(BankAccount bankAccount)
        {
            _sb.AppendLine($"BankAccount;{bankAccount.Id};{bankAccount.Name};{bankAccount.Balance}");
        }

        public void Visit(Category category)
        {
            _sb.AppendLine($"Category;{category.Id};{category.Type};{category.Name}");
        }

        public void Visit(Operation operation)
        {
            _sb.AppendLine($"Operation;{operation.Id};{operation.Type};{operation.BankAccountId};{operation.Amount};{operation.Date};{operation.Description};{operation.CategoryId}");
        }

        public string GetExportResult()
        {
            return _sb.ToString();
        }
    }
}