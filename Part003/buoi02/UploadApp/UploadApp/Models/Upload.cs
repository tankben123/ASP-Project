using System.ComponentModel.DataAnnotations.Schema;

namespace UploadApp.Models
{
    [Table("Upload")]
    public class Upload
    {
        [Column("UploadId")]
        public int Id { get; set; }
        public string OriginalName { get; set; } = null!;

        [Column("UploadUrl")]
        public string Url { get; set; }= null!;

        [Column("UploadType")]
        public string Type { get; set; } = null!;
        public long Size { get; set; }

    }
}
