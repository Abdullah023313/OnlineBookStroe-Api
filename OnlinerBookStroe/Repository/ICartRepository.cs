using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public interface ICartRepository
    {
        Task<Cart> AddBooktoCart(Cart cart);
        Task<List<Cart>?> GetCartForUser(int userId);
        Task DeleteUserItems(int userId);
        Task DeleteItemForCartAsync(Cart cart);
    }
}
