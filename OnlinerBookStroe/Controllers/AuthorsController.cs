using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStroe.Dtos;
using OnlineBookStroe.Model;
using OnlineBookStroe.Repository;

namespace OnlineBookStroe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorRepository authorRepository, IMapper mapper)
        {
            _logger = logger;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string authorName)
        {
            var author = new Author
            {
                AuthorName = authorName,
                IsDelete = false
            };

            await _authorRepository.AddAuthorAsync(author);
            return CreatedAtRoute("GetAuthor", new
            {
                authorId = author.AuthorId,
            }, author);
        }


        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<ActionResult> GetAuthor(int authorId , bool includeBook)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId, includeBook);
            if (author == null)
            {
                return NotFound();
            }

            if(includeBook)
                return Ok(_mapper.Map<AuthorWithBook>(author));
            else
                return Ok(_mapper.Map<AuthorWithoutBook>(author));

        }



        [HttpGet]
        public async Task<ActionResult> GetAuthors() //TODO Filter
        {
            var categorise = await _authorRepository.GetAuthorsAsync();
            return Ok(_mapper.Map<IList<AuthorWithoutBook>>(categorise));

        }


        [HttpDelete("{authorId}")]
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);
            if (author == null)
            {

                return NotFound($"The Author with ID {authorId} could not be found!");
            }
            await _authorRepository.DeleteAsync(author);
            return NoContent();
        }



        [HttpPut("{authorId}")]
        public async Task<ActionResult> UpdateAuthor(string authorName, int authorId)
        {
            var author = await _authorRepository.GetAuthorAsync(authorId);
            if (author == null)
            {
                return NotFound($"The Author with ID {authorId} could not be found!");
            }
            author.AuthorName = authorName;

            await _authorRepository.UpdateAuthorAsync(author);

            return Ok(_mapper.Map<AuthorWithoutBook>(author));
        }
    }
}