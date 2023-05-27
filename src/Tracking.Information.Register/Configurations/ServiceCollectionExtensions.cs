using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Tracking.Information.Register.Services;
using Tracking.Information.Repository.Categories;
using Tracking.Information.Repository.Data;
using Tracking.Information.Repository.Products;
using Tracking.Information.Service.Categories;
using Tracking.Information.Service.Products;

namespace Solisystems.ProductRegistry.Register.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add business layer services.
        /// </summary>
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            return services
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IReadDataService, ReadDataService>()
                .AddScoped<ICategoryService, CategoryService>();
                
        }

        /// <summary>
        /// Add data access services and initialize Db context.
        /// </summary>
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services
                .AddDbContext<ProductRegistryDbContext>(
                    options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=SolisystemsRegister;User Id=postgres;Password=postgres"));
            return services
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
