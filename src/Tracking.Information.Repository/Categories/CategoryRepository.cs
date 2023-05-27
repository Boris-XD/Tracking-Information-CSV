using Microsoft.EntityFrameworkCore;
using Tracking.Information.Repository.Data;

namespace Tracking.Information.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductRegistryDbContext _productRegistryDbContext;
        public CategoryRepository(ProductRegistryDbContext productRegistryDbContext)
        {
            _productRegistryDbContext = productRegistryDbContext;
        }
        public async Task<ICollection<Category>> GetCategories()
        {
            return await _productRegistryDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _productRegistryDbContext.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
        }

        public async Task SaveCategoriesRangeAsync(ICollection<Category> categories)
        {
            _productRegistryDbContext.Categories.AddRange(categories);
            await _productRegistryDbContext.SaveChangesAsync();
        }

        public async Task SaveCategoryAsync(Category category)
        {
            _productRegistryDbContext.Categories.Add(category);
            await _productRegistryDbContext.SaveChangesAsync();
        }
    }
}
