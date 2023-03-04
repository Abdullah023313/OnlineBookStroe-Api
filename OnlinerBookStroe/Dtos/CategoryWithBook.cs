using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Dtos
{
    public class CategoryWithBook
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<BookForResponseDto> books { get; set; } = new List<BookForResponseDto>();
    }
}
