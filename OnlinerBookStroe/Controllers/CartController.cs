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
        public async Task<ActionResult> AddBooktoCart(CartForCreateDto dto , [FromServices] IBookRepository bookRepository)
        {
            if (! await bookRepository.IsValidBook(dto.BookId))
                return BadRequest();

            var item = new Cart()
            {
                BookId = dto.BookId,
                UserId = dto.UserId,
            };
            await _cartRepository.AddBooktoCartAsync(item);
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult> GetCartForUser(int userId)
        {
            var items = await _cartRepository.GetCartForUserAsync(userId);

            if (items == null)
                return BadRequest("No Items");

            return Ok(_mapper.Map<List<CartDto>>(items));
        }


        [HttpDelete(template:"DeleteItem")]
        public async Task<ActionResult> DeleteItemForCartAsync(int ItemId)
        {
            await _cartRepository.DeleteItemForCartAsync(ItemId);
            return NoContent();
        }

        [HttpDelete(template:"DeleteUserItems")]
        public async Task<ActionResult> DeleteUserItemsAsync(int userId)
        {
            await _cartRepository.DeleteUserItemsAsync(userId);
            return NoContent();
        }
    }
}