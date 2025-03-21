using Interfaces;
using Domain;

namespace Patterns.Command
{
    public class AddBankAccountCommand : ICommand
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly int _id;
        private readonly string _name;
        private readonly decimal _initialBalance;

        public AddBankAccountCommand(IBankAccountService bankAccountService, int id, string name, decimal initialBalance)
        {
            _bankAccountService = bankAccountService;
            _id = id;
            _name = name;
            _initialBalance = initialBalance;
        }

        public void Execute()
        {
            _bankAccountService.CreateBankAccount(_id, _name, _initialBalance);
        }
    }
}