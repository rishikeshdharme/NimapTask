using NimapTask.Models;
using NimapTask.Repository;

namespace NimapTask.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo productRepo;
        public ProductService(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task<int> AddProduct(Product product)
        {
            return await productRepo.AddProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await productRepo.DeleteProduct(id);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await productRepo.GetProductByIdAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync(int page, int pageSize)
        {
           return await productRepo.GetProductsAsync(page, pageSize);
        }

        public async Task<int> GetTotalCountAsync()
        {
           return await productRepo.GetTotalCountAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
           return await productRepo.UpdateProduct(product);
        }
    }
}
