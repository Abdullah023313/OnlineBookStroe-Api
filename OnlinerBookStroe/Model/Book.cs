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
        public double FileSize { get; set; }
        public bool IsDelete { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public Author Author { get; set; }=new Author();
        public Category Category { get; set; } = new Category();

    }
}
