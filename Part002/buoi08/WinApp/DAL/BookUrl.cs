using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{

    [Table("BookUrl")]
    public class BookUrl
    {
        // Data access layer  

        [Column("Id")]
        public string Id { get; set; }
    }
}
