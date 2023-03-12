using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;
using OnlineBookStroe.Repository;
using System.Net;

namespace OnlineBookStroe.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly int maxPageSize = 50;

        public BooksController(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> Create(BookForCreateDto dto)
        {

            if (!(await _authorRepository.IsValidAuthor(dto.AuthorId) && await _categoryRepository.IsValidCategory(dto.CategoryId)))
                BadRequest("This authorId or categoryId is not valid");

            var book = _mapper.Map<Book>(dto);
            await _bookRepository.AddBookAsync(book);
            return CreatedAtRoute("GetBook", new
            {
                bookId = book.BookId
            }, book);

        }

        [HttpGet("{bookId}", Name = "GetBook")]
        public async Task<ActionResult> GetBook(int bookId)
        {
            var book = await _bookRepository.GetBookAsync(bookId, true);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));

        }

        [HttpGet]
        public async Task<ActionResult> GetBooks(string? name, int PageNumber = 1, int pageSize = 50) //TODO Filter
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var (books, paginationData) = await _bookRepository.GetBooksAsync(PageNumber, pageSize, name);

            Response.Headers.Add("X-pagination", paginationData.ToString());

            return Ok(_mapper.Map<IList<BookDto>>(books));
        }


        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {

            var book = await _bookRepository.GetBookAsync(bookId);
            if (book == null)
            {

                return NotFound($"The book with ID {bookId} could not be found!");
            }
            await _bookRepository.DeleteAsync(book);
            return NoContent();
        }



        [HttpPut("{bookId}")]
        public async Task<ActionResult> UpdateProduct(BookForCreateDto dto, int bookId)
        {

            var book = await _bookRepository.GetBookAsync(bookId);
            if (book == null)
                return NotFound($"The book with ID {bookId} could not be found!");

            if (await _authorRepository.IsValidAuthor(dto.AuthorId) && await _categoryRepository.IsValidCategory(dto.CategoryId))
            {
                book.AuthorId = dto.AuthorId;
                book.CategoryId = dto.CategoryId;
                book.Name = dto.Name;
                book.Description = dto.Description;
                book.Language = dto.Language;
                book.Pages = dto.Pages;
                book.FileSize = dto.FileSize;
                book.ImagePath = dto.ImagePath;
                book.FilePath = dto.FilePath;
                book.Price = dto.Price;
                await _bookRepository.UpdateBookAsync(book);
            }
            else BadRequest("This authorId or categoryId is not valid");

            return NoContent();
        }
    }
}