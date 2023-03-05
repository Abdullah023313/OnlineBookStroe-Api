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
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartsController(ICartRepository cartRepository , IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult> AddBooktoCart(CartForCreateDto dto , [FromServices] BookRepository bookRepository)
        {
            if (! await bookRepository.IsValidBook(dto.BookId))
                BadRequest();

            var item = new Cart()
            {
                BookId = dto.BookId,
                UserId = dto.UserId,
            };
            await _cartRepository.AddBooktoCart(item);
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult> GetCartForUser(int userId)
        {
            var items = await _cartRepository.GetCartForUser(userId);

            if (items == null)
                return BadRequest("No Items");

            return Ok(_mapper.Map<List<CartDto>>(items));
        }


    }
}