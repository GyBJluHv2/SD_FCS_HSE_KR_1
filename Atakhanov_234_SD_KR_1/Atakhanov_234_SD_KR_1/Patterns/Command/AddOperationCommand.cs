using Interfaces;
using Domain;

namespace Patterns.Command
{
    public class AddOperationCommand : ICommand
    {
        private readonly IOperationService _operationService;
        private readonly int _id;
        private readonly CategoryType _type;
        private readonly int _bankAccountId;
        private readonly decimal _amount;
        private readonly DateTime _date;
        private readonly string _description;
        private readonly int _categoryId;

        public AddOperationCommand(IOperationService operationService,
                                   int id,
                                   CategoryType type,
                                   int bankAccountId,
                                   decimal amount,
                                   DateTime date,
                                   string description,
                                   int categoryId)
        {
            _operationService = operationService;
            _id = id;
            _type = type;
            _bankAccountId = bankAccountId;
            _amount = amount;
            _date = date;
            _description = description;
            _categoryId = categoryId;
        }

        public void Execute()
        {
            _operationService.AddOperation(
                _id, _type, _bankAccountId, _amount, _date, _description, _categoryId
            );
        }
    }
}