namespace Tracking.Information.Repository.Products
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();
        Task SaveProductAsync(Product product);
        Task<Product> GetProductAsync(int id);
    }
}
