using Domain;
using Interfaces;
using YamlDotNet.Serialization;

namespace Patterns.TemplateMethod
{
    public class YamlDataImporter : DataImporterBase
    {
        public YamlDataImporter(IBankAccountService bankAccountService,
                                ICategoryService categoryService,
                                IOperationService operationService)
            : base(bankAccountService, categoryService, operationService)
        {
        }

        protected override void ParseData(string fileContent)
        {
            // Для парсинга YAML используется YamlDotNet, в Package Manager:
            // Install-Package YamlDotNet
            var deserializer = new DeserializerBuilder().Build();
            var operations = deserializer.Deserialize<List<Operation>>(fileContent);

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