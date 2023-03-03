namespace OnlinerBookStroe.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }=new Book();

    }
}
