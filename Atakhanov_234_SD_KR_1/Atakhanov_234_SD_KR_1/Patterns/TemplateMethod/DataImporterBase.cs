using Domain;
using Interfaces;

namespace Patterns.TemplateMethod
{
    /// <summary>
    /// Базовый класс для импорта данных (шаблонный метод).
    /// Он открывает файл, считывает содержимое и передаёт в метод ParseData,
    /// который переопределяется в наследниках под конкретный формат.
    /// </summary>
    public abstract class DataImporterBase
    {
        protected readonly IBankAccountService _bankAccountService;
        protected readonly ICategoryService _categoryService;
        protected readonly IOperationService _operationService;

        protected DataImporterBase(IBankAccountService bankAccountService,
                                   ICategoryService categoryService,
                                   IOperationService operationService)
        {
            _bankAccountService = bankAccountService;
            _categoryService = categoryService;
            _operationService = operationService;
        }

        public void ImportData(string filePath)
        {
            // 1. Считываем файл (общая логика)
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);

            string fileContent = File.ReadAllText(filePath);

            // 2. Парсим содержимое (специфическая логика в наследниках)
            ParseData(fileContent);
        }

        protected abstract void ParseData(string fileContent);
    }
}