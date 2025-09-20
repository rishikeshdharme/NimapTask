using Microsoft.EntityFrameworkCore;
using NimapTask.Appdb;
using System.ComponentModel;

namespace NimapTask.Models
{
    public class ProductDal
    {
        private readonly ApplicationDbContext db;

        public ProductDal(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Product>> GetProductsAsync(int page, int pageSize)
        {
            return await db.Products.Include(p => p.Category).OrderBy(p => p.ProductId).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await db.Products.CountAsync();
        }

        public async Task<int> AddProduct(Product product)
        {
            await db.Products.AddAsync(product);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var pro = db.Products.Find(product.ProductId);
            if (pro != null)
            {
                pro.ProductName = product.ProductName;
                pro.ProductPrice = product.ProductPrice;
            }
            return await db.SaveChangesAsync();

        }

        public async Task<int> DeleteProduct(int id)
        {
            var pro = db.Products.Find(id);
            if (pro != null)
            {
                db.Remove(pro);
            }
            return await db.SaveChangesAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await db.Products
                          .Include(p => p.Category)
                          .FirstOrDefaultAsync(p => p.ProductId == id);
        }


    }
}
