using OnlineBookStroe.Model;

namespace OnlineBookStroe.Repository
{
    public interface ICartRepository
    {
        Task<Cart> AddBooktoCartAsync(Cart cart);
        Task<List<Cart>?> GetCartForUserAsync(int userId);
        Task DeleteUserItemsAsync(int userId);
        Task DeleteItemForCartAsync(int ItemId);
    }
}
