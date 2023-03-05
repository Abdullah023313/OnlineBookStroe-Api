using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineBookStroe.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public bool IsDelete { get; set; } = false;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
