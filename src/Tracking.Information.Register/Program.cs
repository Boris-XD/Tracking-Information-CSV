using Microsoft.Extensions.DependencyInjection;
using Solisystems.ProductRegistry.Register.Configurations;
using Tracking.Information.Register.Services;

namespace Tracking.Information.Register
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                  .AddBusinessService()
                  .AddDataServices()
                  .BuildServiceProvider();

            var demoService = serviceProvider.GetRequiredService<IReadDataService>();
            await demoService.SaveDataFromCSV();
        }
    }
}