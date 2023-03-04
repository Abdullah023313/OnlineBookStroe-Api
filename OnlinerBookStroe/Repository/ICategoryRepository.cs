using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> IsvalidCategory(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesAsync();  //TODO
        Task<Category?> GetCategoryAsync(int categoryId , bool includeBook=false);
        Task UpdateCategoryAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
