using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Address")]
    public class Address
    {
        [Column("AddressId")]
        public int Id { get; set; }

        [Column("WardId")]
        public int WardId { get; set; }

        [Column("AddressName")]
        public string Name { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Ward? Ward { get; set; }
    }
}
