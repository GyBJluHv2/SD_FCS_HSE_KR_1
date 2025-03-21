namespace Domain
{
    public enum CategoryType
    {
        Income,
        Expense
    }

    public class Category
    {
        public int Id { get; private set; }
        public CategoryType Type { get; private set; }
        public string Name { get; private set; }

        public Category(int id, CategoryType type, string name)
        {
            Id = id;
            Type = type;
            Name = name;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateType(CategoryType newType)
        {
            Type = newType;
        }
    }
}