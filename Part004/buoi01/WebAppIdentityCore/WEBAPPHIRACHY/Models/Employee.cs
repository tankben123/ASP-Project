using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Column("Employee")]
        public int EmployeeId { get; set; }

        [Column("FirstName")]
        [Required]
        public string? FirstName { get; set; }

        [Column("LastName")]
        [Required]
        public string? LastName { get; set; }

        [Column("Gender")]
        public bool Gender { get; set; }

        [Column("Email")]
        [Required, EmailAddress]
        public string? Email { get; set; }

        [Column("Phone")]
        [Required]
        public string? Phone { get; set; }

        public int? ParentId { get; set; }
    }
}
