using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Dtos
{
    public class BookForDisplayDto
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int Pages { get; set; }
        public int Price { get; set; }
        public double FileSize { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
