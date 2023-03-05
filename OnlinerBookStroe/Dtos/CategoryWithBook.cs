using OnlineBookStroe.Model;

namespace OnlineBookStroe.Dtos
{
    public class CategoryWithBook
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<BookDto> books { get; set; } = new List<BookDto>();
    }
}
