namespace Domain
{
    public class Operation
    {
        public int Id { get; private set; }
        public CategoryType Type { get; private set; }
        public int BankAccountId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }

        public Operation(int id, CategoryType type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            if (amount < 0)
                throw new ArgumentException("Operation amount cannot be negative.");

            Id = id;
            Type = type;
            BankAccountId = bankAccountId;
            Amount = amount;
            Date = date;
            Description = description;
            CategoryId = categoryId;
        }
    }
}