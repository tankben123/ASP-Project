using System.ComponentModel.DataAnnotations.Schema;

namespace WebUpload.Models
{
    [Table("Image")]
    public class Image
    {
        [Column("ImageId")]
        public int Id { get; set; }

        [Column("ImageUrl")]
        public string Url { get; set; } = null!;


        [Column("OriginalName")]
        public string OriginalName { get; set; } = null!;

        [Column("Size")]
        public long Size { get; set; }

        [Column("ImageType")]
        public string Type { get; set; } = null!;

    }
}
