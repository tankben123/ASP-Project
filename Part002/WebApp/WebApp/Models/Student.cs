using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Student")]
    public class Student
    {
        [Column("StudentId")]
        public int Id { get; set; }
        [Column("FullName")]

        public string Fullname { get; set; } = null!;
        [Column("Email")]

        public string Email { get; set; } = null!;
        [Column("Gender")]

        public bool  Gender { get; set; }
        [Column("DateOfBirth")]

        public DateTime DateOfBirth { get; set; }
    }
}
