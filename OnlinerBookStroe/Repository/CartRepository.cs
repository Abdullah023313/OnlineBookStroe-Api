using Microsoft.EntityFrameworkCore;
using OnlineBookStroe.Data;
using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public class CartRepository : ICartRepository
    {

        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cart> AddBooktoCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task DeleteItemForCartAsync(int ItemId)
        {
            var Item = await _context.Carts.Where(c => c.ItemId == ItemId).FirstOrDefaultAsync();
            if (Item != null)
            {
                _context.Carts.Remove(Item);
                await _context.SaveChangesAsync();
            }         
        }


        public async Task DeleteUserItemsAsync(int userId)
        {
            var Items = await _context.Carts.Where(c => c.UserId== userId).ToListAsync();
            if (Items != null)
            {
                _context.Carts.RemoveRange(Items);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<Cart>?> GetCartForUserAsync(int userId)
        {
            return await _context.Carts
                .Where(c => c.UserId== userId) 
                .Include(c=>c.Book)
                .ToListAsync();
        }
    }
}