using Microsoft.EntityFrameworkCore;
using Tracking.Information.Repository.Categories;
using Tracking.Information.Repository.Products;

namespace Tracking.Information.Repository.Data
{
    public class ProductRegistryDbContext : DbContext
    {
        private const string connectionString = @"Server=127.0.0.1;Port=5432;Database=SolisystemsRegister;User Id=postgres;Password=postgres;";

        public ProductRegistryDbContext(DbContextOptions<ProductRegistryDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
