using Domain;

namespace Repository
{
    public interface IOperationRepository
    {
        void Add(Operation operation);
        Operation GetById(int id);
        void Delete(int id);
        List<Operation> GetAll();
    }
}