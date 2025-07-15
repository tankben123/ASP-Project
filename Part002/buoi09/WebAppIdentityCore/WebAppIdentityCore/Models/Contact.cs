using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppIdentityCore.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Column("ContactId")]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
    }
}
