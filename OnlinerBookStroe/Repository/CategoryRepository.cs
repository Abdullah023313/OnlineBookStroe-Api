using Microsoft.EntityFrameworkCore;
using OnlineBookStroe.Data;
using OnlineBookStroe.Model;
using System.Net;

namespace OnlineBookStroe.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ILogger<ICategoryRepository> _logger;
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ILogger<ICategoryRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            category.IsDelete = true;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId, bool includeBook)
        {
            if (includeBook)
                return await _context.Categories.Where(c => c.CategoryId == categoryId && c.IsDelete == false)
                    .Include(c => c.Books).ThenInclude(a => a.Author)
                    .SingleOrDefaultAsync();

            else
                return await _context.Categories.SingleOrDefaultAsync(c => c.CategoryId == categoryId && c.IsDelete == false);

        }

        public async Task<bool> IsValidCategory(int categoryId)
        {
            return await _context.Categories
           .AnyAsync(c => c.CategoryId == categoryId && c.IsDelete == false); ;

        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}