using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("SubCategory")]
    public class SubCategory
    {
        public int Id { get; set; }

        [Column("CategoryId")]
        public byte CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}
