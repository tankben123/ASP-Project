using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Book")]
    public class Book
    {
        [Column("BookId")]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Ratings { get; set; }
        public string Url { get; set; } = null!;
    }
}
