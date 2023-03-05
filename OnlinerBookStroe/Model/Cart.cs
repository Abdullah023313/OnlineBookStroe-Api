using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OnlineBookStroe.Model
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool IsDelete { get; set; } = false;

        public Book Book { get; set; } = null!;
    }
}
