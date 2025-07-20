using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("District")]
    public class District
    {
        [Column("DistrictId")]
        public Byte Id { get; set; }

        [Column("DistrictName")]
        public string? Name { get; set; }

        [Column("ProvinceId")]
        public Byte ProvinceId { get; set; }
        public Province? Province { get; set; }

        public List<Ward>? Wards { get; set; }
    }
}
