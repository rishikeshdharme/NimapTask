using Microsoft.EntityFrameworkCore;
using NimapTask.Appdb;
using NimapTask.Models;

namespace NimapTask.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepo(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<int> AddCategoryAsync(Category category)
        {
            _db.Categories.Add(category);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<int> UpdateCategoryAsync(Category category)
        {
            var cat = _db.Categories.Find(category.CategoryId);
            if (cat != null)
            {
                cat.CategoryName = category.CategoryName;
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}
