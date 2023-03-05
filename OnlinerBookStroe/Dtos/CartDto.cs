namespace OnlineBookStroe.Dtos
{
    public class CartDto
    {
        public int UserId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public int BookPrice{get; set;}
        public string BookImagePath { get; set; } = string.Empty;

    }
}
