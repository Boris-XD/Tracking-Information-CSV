using Tracking.Information.Repository.Categories;

namespace Tracking.Information.Service.Categories
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category> SaveCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int id);
        Task SaveCategoriesRangeAsync(ICollection<Category> categories);
    }
}
