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
        [Column("AttributeId")]
        public int AttributeId  { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("AttributeValue")]
        public string Value { get; set; } = null!;
    }
}
