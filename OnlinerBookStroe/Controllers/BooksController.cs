using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;
using OnlinerBookStroe.Repository;

namespace OnlinerBookStroe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly int maxPageSize = 50;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookDto dto)
        {
            var book = new Book()
            {
              

            };
            await _bookRepository.AddBookAsync(book);

            return CreatedAtRoute("GetBook", new
            {
               bookId = book.BookId
            }, book);
        }
    }
}
