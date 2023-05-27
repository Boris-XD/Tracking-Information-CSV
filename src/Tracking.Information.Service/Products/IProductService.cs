using Tracking.Information.Repository.Products;

namespace Tracking.Information.Service.Products
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProductsAsync();
        Task<Product> SaveProductAsync(Product product);
        Task<Product> GetProductAsync(int id);
    }
}
