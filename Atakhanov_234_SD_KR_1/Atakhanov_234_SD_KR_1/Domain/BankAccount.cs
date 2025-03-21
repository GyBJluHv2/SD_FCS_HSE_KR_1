namespace Domain
{
    public class BankAccount
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(int id, string name, decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            Id = id;
            Name = name;
            Balance = initialBalance;
        }

        public void UpdateBalance(decimal amount)
        {
            Balance += amount;
        }
    }
}