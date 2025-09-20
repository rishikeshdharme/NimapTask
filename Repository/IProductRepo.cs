using NimapTask.Models;

namespace NimapTask.Repository
{
    public interface IProductRepo
    {
        public  Task<List<Product>> GetProductsAsync(int page, int pageSize);
        public  Task<int> GetTotalCountAsync();
        public  Task<int> AddProduct(Product product);
        public Task<int> UpdateProduct(Product product);
        public Task<int> DeleteProduct(int id);
        public Task<Product?> GetProductByIdAsync(int id);


    }
}
