using Tracking.Information.Repository.Categories;

namespace Tracking.Information.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategories();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return _categoryRepository.GetCategoryAsync(id);
        }

        public async Task SaveCategoriesRangeAsync(ICollection<Category> categories)
        {
            await _categoryRepository.SaveCategoriesRangeAsync(categories);
        }

        public async Task<Category> SaveCategoryAsync(Category category)
        {
            await _categoryRepository.SaveCategoryAsync(category);
            return category;
        }
    }
}
