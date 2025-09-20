using NimapTask.Models;

namespace NimapTask.Repository
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<int> AddCategoryAsync(Category category);
        public Task<int> UpdateCategoryAsync(Category category);
        public Task<int> DeleteCategoryAsync(int id);

    }
}
