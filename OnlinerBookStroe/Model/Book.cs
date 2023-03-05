using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookStroe.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Language { get; set; } = null!;
        public int Pages { get; set; }

        public int Price { get; set; }
        public double FileSize { get; set; }
        public bool IsDelete { get; set; } = false;
        public string ImagePath { get; set; } = null!;
        public string FilePath { get; set; } = null!;

        public Author Author { get; set; } = null!;
        public Category Category { get; set; } = null!;

    }
}
