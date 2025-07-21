using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Ward")]
    public class Ward
    {
        [Column("WardId")]
        public int Id { get; set; }

        [Column("WardName")]
        public string Name { get; set; }

        [Column("DistrictId")]
        public byte DistrictId { get; set; }

        public District? Districts { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}
