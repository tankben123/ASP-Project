using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    [Table("Image")]
    public class Image
    {
        [Column("ImageId")]
        public int Id { get; set; }

        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("OriginalName")]
        public string? OriginalName { get; set; }

        [Column("Size")]
        public long Size { get; set; }

        [Column("ImageType")]
        public string? Type { get; set; }
    }
}
 