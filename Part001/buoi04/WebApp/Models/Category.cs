using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Category")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Category")]
        public byte Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; } = null!;
    }
}
