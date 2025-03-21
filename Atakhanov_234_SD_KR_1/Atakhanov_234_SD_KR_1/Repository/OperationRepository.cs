using Domain;

namespace Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly List<Operation> _operations = new List<Operation>();

        public void Add(Operation operation)
        {
            _operations.Add(operation);
        }

        public Operation GetById(int id)
        {
            return _operations.FirstOrDefault(op => op.Id == id);
        }

        public void Delete(int id)
        {
            var op = GetById(id);
            if (op != null)
            {
                _operations.Remove(op);
            }
        }

        public List<Operation> GetAll()
        {
            return _operations;
        }
    }
}