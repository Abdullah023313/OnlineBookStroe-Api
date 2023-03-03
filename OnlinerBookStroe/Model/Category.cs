using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlinerBookStroe.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Book> books { get; set; } = new List<Book>();
    }
}
