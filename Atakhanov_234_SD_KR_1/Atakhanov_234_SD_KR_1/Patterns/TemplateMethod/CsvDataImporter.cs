using Domain;
using Interfaces;

namespace Patterns.TemplateMethod
{
    public class CsvDataImporter : DataImporterBase
    {
        public CsvDataImporter(IBankAccountService bankAccountService,
                               ICategoryService categoryService,
                               IOperationService operationService)
            : base(bankAccountService, categoryService, operationService)
        {
        }

        protected override void ParseData(string fileContent)
        {
            // Пример примитивного парсинга CSV.
            // Допустим формат: "Type,BankAccountId,Amount,Date,Description,CategoryId"
            // Строки разделены \n

            var lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var columns = line.Split(',');
                if (columns.Length < 6) continue;

                var type = (CategoryType)Enum.Parse(typeof(CategoryType), columns[0]);
                int bankAccountId = int.Parse(columns[1]);
                decimal amount = decimal.Parse(columns[2]);
                DateTime date = DateTime.Parse(columns[3]);
                string description = columns[4];
                int categoryId = int.Parse(columns[5]);

                // Добавляем через сервис
                _operationService.AddOperation(
                    id: new Random().Next(1000, 9999), // Для примера генерируем случайный ID
                    type: type,
                    bankAccountId: bankAccountId,
                    amount: amount,
                    date: date,
                    description: description,
                    categoryId: categoryId
                );
            }
        }
    }
}