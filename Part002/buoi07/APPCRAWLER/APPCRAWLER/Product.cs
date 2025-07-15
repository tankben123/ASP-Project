using System.ComponentModel.DataAnnotations.Schema;

namespace APPCRAWLER
{
    [Table("Product")]
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }

        [Column("CategoryId")]
        public byte CategoryId { get; set; }

        [Column("Title")]
        public string Title { get; set; } = null!;


        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }


        [Column("ISBN")]
        public string? ISBN { get; set; }

        [Column("ImageUrl")]
        public string ImageUrl { get; set; } = null!;
    }
}
