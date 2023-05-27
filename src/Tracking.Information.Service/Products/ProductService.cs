using Solisystems.ProductRegistry.Repositories.Products;

namespace Tracking.Information.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProducts();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productRepository.GetProductAsync(id);
        }

        public async Task<Product> SaveProductAsync(Product product)
        {
            await _productRepository.SaveProductAsync(product);
            return product;
        }
    }
}
