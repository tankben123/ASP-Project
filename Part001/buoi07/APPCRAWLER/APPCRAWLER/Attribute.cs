using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    [Table("Attribute")]
    public class Attribute
    {
        [Column("AttributeId")]
        public short Id { get; set; }

        [Column("AttributeName")]
        public string Name { get; set; } = null!;

        [Column("AttributeNameVI")]
        public  string NameVI { get; set; } = null!;
    }
}
