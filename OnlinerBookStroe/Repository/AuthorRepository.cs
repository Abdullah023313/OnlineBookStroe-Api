using Microsoft.EntityFrameworkCore;
using OnlineBookStroe.Data;
using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task DeleteAsync(Author author)
        {
            author.IsDelete = true;
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>?> GetAuthorsAsync()
        {
            return await _context.Authors.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<Author?> GetAuthorAsync(int authorId, bool includeBook = false)
        {
            if (includeBook)
            {
                return await _context.Authors.Where(a => a.AuthorId == authorId && a.IsDelete == false)
                    .Include(c => c.books).ThenInclude(C => C.Category)
                    .SingleOrDefaultAsync();
            }

            else  return await _context.Authors.SingleOrDefaultAsync(a => a.AuthorId == authorId && a.IsDelete == false);
        }


        public async Task<bool> IsValidAuthor(int authorId)
        {
            return await _context.Authors
            .AnyAsync(a => a.AuthorId == authorId && a.IsDelete == false); ;
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

    }
}