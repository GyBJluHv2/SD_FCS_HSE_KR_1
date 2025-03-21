using Interfaces;
using Domain;

namespace Patterns.Command
{
    public class AddCategoryCommand : ICommand
    {
        private readonly ICategoryService _categoryService;
        private readonly int _id;
        private readonly CategoryType _type;
        private readonly string _name;

        public AddCategoryCommand(ICategoryService categoryService, int id, CategoryType type, string name)
        {
            _categoryService = categoryService;
            _id = id;
            _type = type;
            _name = name;
        }

        public void Execute()
        {
            _categoryService.CreateCategory(_id, _type, _name);
        }
    }
}