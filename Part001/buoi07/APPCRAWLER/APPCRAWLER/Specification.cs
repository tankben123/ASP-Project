using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    [Table("Specification")]
    public class Specification
    {
        [Column("ProductId")]
        public short AttributeId  { get; set; }

        [Column("AttributeId")]
        public int ProductId { get; set; }

        [Column("AttributeValue")]
        public string Value { get; set; } = null!;
    }
}
