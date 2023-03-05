using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public interface IAuthorRepository
    {
        Task<bool> IsValidAuthor(int authorId);
        Task<Author> AddAuthorAsync(Author author);
        Task<List<Author>?> GetAuthorsAsync();
        Task<Author?> GetAuthorAsync(int authorId, bool includeBook = false);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAsync(Author author);
    }
}
