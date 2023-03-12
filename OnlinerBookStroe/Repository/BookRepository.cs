using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineBookStroe.Data;
using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;
using OnlineBookStroe.Services;
using System;
using System.Data;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace OnlineBookStroe.Repository
{
    public class BookRepository:IBookRepository
    {
        private readonly ILogger<IBookRepository> _logger;
        private readonly ApplicationDbContext _context;

        public BookRepository(ILogger<IBookRepository> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Book> AddBookAsync(Book Book)
        {
            await _context.Books.AddAsync(Book);
            await _context.SaveChangesAsync();
            return Book;
        }

        public async Task<(List<Book>?, PaginationMetaData)> GetBooksAsync(int pageNumber,int pageSize, string name)
        {
            var totalProducts = await _context.Books.CountAsync();

            var paginationMetaData = new PaginationMetaData(totalProducts, pageSize, pageNumber);

            var query = _context.Books as IQueryable<Book>;

            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(name));
            }

            var filterBooks = await query
                .Where(b => b.IsDelete == false)
                .OrderBy(b => b.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Include(b => b.Category)
                .Include(b=>b.Author)
                .ToListAsync();

            return (filterBooks, paginationMetaData);
        }

        public async Task<Book?> GetBookAsync(int BookId, bool includeAllInfo = false)
        {
            if (includeAllInfo)
                return await _context.Books
                    .Include(c => c.Category)
                    .Include(a => a.Author)
                    .SingleOrDefaultAsync(b => b.BookId == BookId && b.IsDelete == false);
            else
                return await _context.Books.SingleOrDefaultAsync(
                    b => b.BookId == BookId && b.IsDelete == false
                );
        }

        public async Task<bool> IsValidBook(int BookId)
        {
            return await _context.Books.AnyAsync(b => b.BookId == BookId && b.IsDelete == false);
            ;
        }

        public async Task DeleteAsync(Book Book)
        {
            Book.IsDelete = true;
            _context.Books.Update(Book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book Book)
        {
            _context.Books.Update(Book);
            await _context.SaveChangesAsync();
        }
    }
}
