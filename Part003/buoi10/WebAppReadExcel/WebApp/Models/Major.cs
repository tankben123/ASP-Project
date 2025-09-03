using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Major")]
    public class Major
    {
        [Required(ErrorMessage = "nhập Id nhé")]
        [StringLength(maximumLength:7, MinimumLength =7, ErrorMessage = "Id phải có 7 ký tự.")]
        [Column("MajorId")]
        public string? MajorId { get; set; }

        [Column("MajorName")]
        [Required(ErrorMessage = "Nhập tên nhé")]
        [MaxLength(64, ErrorMessage = "Tên chuyên ngành không được vượt quá 100 ký tự.")]
        public string? MajorName { get; set; }
    }
}
