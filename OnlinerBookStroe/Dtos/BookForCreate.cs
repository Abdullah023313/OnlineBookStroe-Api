using OnlineBookStroe.Model;

namespace OnlineBookStroe.Dtos
{
    public class BookForCreateDto
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;

        public int Price { get; set; }
        public int Pages { get; set; }
        public double FileSize { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
