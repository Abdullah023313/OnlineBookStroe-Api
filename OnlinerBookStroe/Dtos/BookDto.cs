using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Dtos
{
    public class BookDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int Pages { get; set; }
        public double FileSize { get; set; }
        public bool IsDelete { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
