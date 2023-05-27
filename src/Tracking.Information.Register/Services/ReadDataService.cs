using Tracking.Information.Register.Constants;
using Tracking.Information.Repository.Categories;
using Tracking.Information.Repository.Products;
using Tracking.Information.Service.Categories;
using Tracking.Information.Service.Products;

namespace Tracking.Information.Register.Services
{
    public class ReadDataService : IReadDataService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly string _currentPath;
        public ReadDataService(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _currentPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
        }

        public async Task SaveDataFromCSV()
        {

            await ReadDataAsync(async (string[] category)
                => await SaveCategoryInformation(category));

            await ReadDataAsync(async (string[] product)
                => await SaveProductInformation(product));


        }

        private async Task ReadDataAsync(Func<string[], Task> saveData)
        {
            string filePath = $"{_currentPath}Files\\product.csv";
            using (var reader = new StreamReader(filePath))
            {
                string separator = ";";
                string row = string.Empty;
                reader.ReadLine();
                while ((row = reader.ReadLine()) != null)
                {
                    string[] newRow = row.Split(separator);
                    await saveData(newRow);
                }
            }
        }

        private async Task SaveCategoryInformation(string[] category)
        {
            int categoryCode = int.Parse(category[IndexValue.CategoryCode]);
            string categoryName = category[IndexValue.CategoryName];

            var categoryResult = await _categoryService.GetCategoryAsync(categoryCode);
            if (categoryResult == null)
            {
                var newCategory = new Category
                {
                    Id = categoryCode,
                    Name = categoryName,
                    Creation = DateTime.Now.ToUniversalTime()
                };

                await _categoryService.SaveCategoryAsync(newCategory);
            }
        }

        private async Task SaveProductInformation(string[] product)
        {
            int productCode = int.Parse(product[IndexValue.ProductCode]);
            string productName = product[IndexValue.ProductName];
            int categoryCode = int.Parse((product[IndexValue.ProductCategoryCode]));

            var productResult = await _productService.GetProductAsync(productCode);

            if (productResult == null)
            {
                var newProduct = new Product
                {
                    Id = productCode,
                    Name = productName,
                    Creation = DateTime.Now.ToUniversalTime(),
                    CategoryId = categoryCode,
                };

                await _productService.SaveProductAsync(newProduct);
            }
        }
    }
}