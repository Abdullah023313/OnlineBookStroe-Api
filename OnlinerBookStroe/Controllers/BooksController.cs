using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;
using OnlinerBookStroe.Repository;
using System.Net;

namespace OnlinerBookStroe.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly int maxPageSize = 50;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository, IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookDto dto)
        {

            //TODO  Check if it is Id correct
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
            return Ok(_mapper.Map<BookForResponseDto>(book));
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks(string? name, int PageNumber = 1, int pageSize = 50) //TODO Filter
        {
            pageSize = pageSize > maxPageSize ? maxPageSize : pageSize;

            var (books, paginationData) = await _bookRepository.GetBooksAsync(PageNumber, pageSize, name: name);

            Response.Headers.Add("X-pagination", paginationData.ToString());

            return Ok(_mapper.Map<IList<BookForResponseDto>>(books));
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
        public async Task<ActionResult> UpdateProduct(BookDto dto, int bookId)
        {

            var book = await _bookRepository.GetBookAsync(bookId);
            if (book == null)
            {
               
                return NotFound($"The book with ID {bookId} could not be found!");
            }

           
            book.AuthorId = dto.AuthorId;     //TODO  Check if it is Id correct
            book.CategoryId = dto.CategoryId;     //TODO  Check if it is Id correct
            book.Name = dto.Name;
            book.Description = dto.Description;
            book.Language = dto.Language;
            book.Pages = dto.Pages;
            book.FileSize = dto.FileSize;
            book.ImagePath = dto.ImagePath;
            book.FilePath = dto.FilePath;
            book.Price = dto.Price;

            await _bookRepository.UpdateBookAsync(book);

            return NoContent();
        }


    }
}