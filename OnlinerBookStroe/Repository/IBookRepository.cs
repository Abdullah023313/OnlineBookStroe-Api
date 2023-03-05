using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;
using System;

namespace OnlineBookStroe.Repository
{
    public interface IBookRepository
    {
        Task<bool> IsValidBook(int BookId);
        Task<Book> AddBookAsync(Book Book);
        Task<(List<Book>?, PaginationMetaData)> GetBooksAsync(int pageNumber, int pageSize, string name);  //TODO
        Task<Book?> GetBookAsync(int BookId, bool includeAllInfo = false);
        Task UpdateBookAsync(Book Book);
        Task DeleteAsync(Book Book);
    }
}
