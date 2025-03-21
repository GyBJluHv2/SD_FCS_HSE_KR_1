using Domain;
using Interfaces;
using System.Text.Json;

namespace Patterns.TemplateMethod
{
    public class JsonDataImporter : DataImporterBase
    {
        public JsonDataImporter(IBankAccountService bankAccountService,
                                ICategoryService categoryService,
                                IOperationService operationService)
            : base(bankAccountService, categoryService, operationService)
        {
        }

        protected override void ParseData(string fileContent)
        {
            // Предположим, что JSON – это список операций
            // [{"Id":1,"Type":"Income","BankAccountId":1,"Amount":1000,"Date":"2025-03-17T00:00:00","Description":"Salary","CategoryId":2}, ...]

            var operations = JsonSerializer.Deserialize<List<Operation>>(fileContent);
            if (operations == null) return;

            foreach (var op in operations)
            {
                _operationService.AddOperation(
                    op.Id,
                    op.Type,
                    op.BankAccountId,
                    op.Amount,
                    op.Date,
                    op.Description,
                    op.CategoryId
                );
            }
        }
    }
}