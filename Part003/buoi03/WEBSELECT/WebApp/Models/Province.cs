using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Province")]
    public class Province
    {
        [Column("ProvinceId")]
        public Byte Id { get; set; }

        [Column("ProvinceName")]
        public string? Name { get; set; }

        public List<District>? Districts { get; set; }
    }
}
