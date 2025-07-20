using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Category")]
    public class Category
    {
        [Column("CategoryId")]
        public byte Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public string? Filter { get; set; }

        public List<SubCategory> SubCategories { get; set; } = null!;
    }
}
