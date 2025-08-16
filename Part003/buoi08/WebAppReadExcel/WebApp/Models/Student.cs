using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Student")]
    public class Student
    {
        public string? FullName { get; set; } 
        public string? DateOfBirth { get; set; } 
        public bool Gender { get; set; } 
        public string? IdentificationNumber { get; set; } 
        public string? Subject { get; set; }
        public string? Area { get; set; } 
        public decimal Score1 { get; set; } 
        public decimal Score2 { get; set; } 
        public decimal Score3 { get; set; } 
        public int SrNo { get; set; } 
        public string? MajorId { get; set; } 
        public decimal ScoreAreaExtra { get; set; } 
        public decimal ScoreExtra { get; set; } 
    }
}
