using Microsoft.EntityFrameworkCore;
using Tracking.Information.Repository.Categories;
using Tracking.Information.Repository.Products;

namespace Tracking.Information.Repository.Data
{
    public class ProductRegistryDbContext : DbContext
    {
        public ProductRegistryDbContext(DbContextOptions<ProductRegistryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
