using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CategoryId")]
        public byte Id { get; set; }
        [Column("CategoryName")]
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
    }
}
