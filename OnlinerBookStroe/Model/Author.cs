using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlinerBookStroe.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }=string.Empty;

        public bool IsDelete { get; set; } = false;
        public List<Book> books { get; set; } = new List<Book>();
    }
}
