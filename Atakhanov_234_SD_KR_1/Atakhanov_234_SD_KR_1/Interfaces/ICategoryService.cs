using Domain;

namespace Interfaces
{
    public interface ICategoryService
    {
        Category CreateCategory(int id, CategoryType type, string name);
        Category GetCategoryById(int id);
        void UpdateCategory(int id, string newName, CategoryType newType);
        void DeleteCategory(int id);
        List<Category> GetAllCategories();
    }
}