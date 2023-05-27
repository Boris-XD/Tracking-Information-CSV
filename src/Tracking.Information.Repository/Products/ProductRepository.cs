using Microsoft.EntityFrameworkCore;
using Tracking.Information.Repository.Data;

namespace Tracking.Information.Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductRegistryDbContext _productRegistryDbContext;

        public ProductRepository(ProductRegistryDbContext productRegistryDbContext)
        {
            _productRegistryDbContext = productRegistryDbContext;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productRegistryDbContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _productRegistryDbContext.Products.ToListAsync();
        }

        public async Task SaveProductAsync(Product product)
        {
            _productRegistryDbContext.Products.Add(product);
            await _productRegistryDbContext.SaveChangesAsync();
        }
    }
}
