using NimapTask.Models;
using NimapTask.Repository;

namespace NimapTask.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo crepo;
        public CategoryService(ICategoryRepo _crepo)
        {
            crepo = _crepo;
        }

        public Task<int> AddCategoryAsync(Category category)
        {
            return crepo.AddCategoryAsync(category);
        }

        public Task<int> DeleteCategoryAsync(int id)
        {
            return crepo.DeleteCategoryAsync(id);
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            return crepo.GetAllCategoriesAsync();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            return crepo.GetCategoryByIdAsync(id);
        }

        public Task<int> UpdateCategoryAsync(Category category)
        {
            return crepo.UpdateCategoryAsync(category);
        }
    }
}
