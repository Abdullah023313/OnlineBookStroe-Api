using System.ComponentModel.DataAnnotations.Schema;

namespace OnlinerBookStroe.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int Pages { get; set; }

        public int Price { get; set; }
        public double FileSize { get; set; }
        public bool IsDelete { get; set; } = false;
        public string ImagePath { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        public Author Author { get; set; }
        public Category Category { get; set; }

    }
}
