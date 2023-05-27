namespace Tracking.Information.Repository.Categories
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategories();
        Task SaveCategoryAsync(Category category);
        Task SaveCategoriesRangeAsync(ICollection<Category> categories);
        Task<Category> GetCategoryAsync(int id);
    }
}
