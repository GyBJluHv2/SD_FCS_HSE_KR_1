using Domain;
using Interfaces;
using Repository;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CreateCategory(int id, CategoryType type, string name)
        {
            var category = new Category(id, type, name);
            _categoryRepository.Add(category);
            return category;
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void UpdateCategory(int id, string newName, CategoryType newType)
        {
            var category = _categoryRepository.GetById(id);
            if (category != null)
            {
                category.UpdateName(newName);
                category.UpdateType(newType);
            }
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}