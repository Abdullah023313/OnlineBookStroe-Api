using Microsoft.EntityFrameworkCore;
using OnlineBookStroe.Data;
using OnlineBookStroe.Model;
using OnlineBookStroe.Repository;
using System.Text.Json;

namespace OnlineBookStroe.Services
{
    public class FakeDataService : IFakeDataService
    {
        private readonly ILogger<IFakeDataService> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IFilesService _filesService;

        public FakeDataService(ILogger<IFakeDataService> logger, ApplicationDbContext context , IFilesService filesService)
        {
            _logger = logger;
            _context = context;
            _filesService = filesService;
        }

       

        public async Task FakeDate()
        {
            try
            {

                string jsonAuthors = ("Authors.json");
                var Authors = JsonSerializer.Deserialize<List<Author>>(jsonAuthors);

                string jsonCategories =await _filesService.ReadJsonFile("Categories.json");
                var Categories = JsonSerializer.Deserialize<List<Category>>(jsonCategories);

                string jsonbooks =await _filesService.ReadJsonFile("Books.json");
                var Books = JsonSerializer.Deserialize<List<Book>>(jsonbooks);

                await _context.Authors.AddRangeAsync(Authors);
                await _context.Categories.AddRangeAsync(Categories);

                _context.SaveChanges();



                int minAuthorId = _context.Authors.Min(a => a.AuthorId);
                int maxAuthorId = _context.Authors.Max(a => a.AuthorId);

                int minCategoryId = _context.Categories.Min(c => c.CategoryId);
                int maxCategoryId = _context.Categories.Max(c => c.CategoryId);

                var random = new Random();

                foreach (var item in Books)
                {
                    item.AuthorId = random.Next(minAuthorId, maxAuthorId);
                    item.CategoryId = random.Next(minCategoryId, maxCategoryId);
                    await _context.Books.AddAsync(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.StackTrace);
            }
        }
    }
}