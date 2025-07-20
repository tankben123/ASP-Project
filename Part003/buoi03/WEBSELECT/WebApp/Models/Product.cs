using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        [Column("Priceorigin")]
        public double PriceOrigin { get; set; }

        public string Image { get; set; } = null!;

        public string Content { get; set; } = null!;

        public string Filter { get; set; } = null!;

        public bool Featured { get; set; }

        public int Selling { get; set; }

        public int View { get; set; }

        public string Public { get; set; } = null!;

        [Column("SubCategory")]
        public int SubCategoryId { get; set; }

        public SubCategory? SubCategory { get; set; }
    }
}
