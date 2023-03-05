namespace OnlineBookStroe.Dtos
{
    public class AuthorWithBook
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public List<BookDto> books { get; set; } = new List<BookDto>();
    }
}
