using OnlineBookStroe.Model;

namespace OnlineBookStroe.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int Pages { get; set; }
        public int Price { get; set; }
        public double FileSize { get; set; }
        public string ImagePath { get; set; } = null!;
        public string FilePath { get; set; } = null!;
    }
}