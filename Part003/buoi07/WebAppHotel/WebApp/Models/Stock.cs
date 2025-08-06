using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApp.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("Open")]
        public double Open { get; set; }

        [Column("High")]
        public double High { get; set; }

        [Column("Low")]
        public double Low { get; set; }

        [Column("Close")]
        public double Close { get; set; }

        [Column("AdjClose")]
        public double AdjClose { get; set; }

        [Column("Volume")]
        public int Volume { get; set; }
    }
}
