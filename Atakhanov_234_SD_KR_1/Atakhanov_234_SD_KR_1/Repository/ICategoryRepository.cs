using Domain;

namespace Repository
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        void Delete(int id);
        List<Category> GetAll();
    }
}