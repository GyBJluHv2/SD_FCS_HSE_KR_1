namespace Patterns.Visitor
{
    using Domain;

    public interface IVisitor
    {
        void Visit(BankAccount bankAccount);
        void Visit(Category category);
        void Visit(Operation operation);
    }
}