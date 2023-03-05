using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> IsValidCategory(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync();  //TODO
        Task<Category?> GetCategoryAsync(int categoryId , bool includeBook=false);
        Task UpdateCategoryAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
