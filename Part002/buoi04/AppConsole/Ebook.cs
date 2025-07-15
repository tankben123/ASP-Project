using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    [Table("Book")]
    internal class Ebook
    {
        [Column("BookId")]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int Ratings { get; set; }
        public string Url { get; set; } = null!;
    }
}
