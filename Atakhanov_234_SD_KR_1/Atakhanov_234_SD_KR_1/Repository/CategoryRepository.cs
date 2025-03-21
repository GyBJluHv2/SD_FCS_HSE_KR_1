using Domain;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new List<Category>();

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public Category GetById(int id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }

        public List<Category> GetAll()
        {
            return _categories;
        }
    }
}