using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;
using System;

namespace OnlinerBookStroe.Repository
{
    public interface IBookRepository
    {
        Task<bool> IsvalidBook(int BookId);
        Task<Book> AddBookAsync(Book Book);
        Task<(List<Book>? , PaginationMetaData)> GetBooksAsync(int pageNumber, int pageSize, string name);  //TODO
        Task<Book?> GetBookAsync(int BookId, bool includeBrands = false);
        Task UpdateBookAsync(Book Book);
        Task DeleteAsync(Book Book);
    }
}
