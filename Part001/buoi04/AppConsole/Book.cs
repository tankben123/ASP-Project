using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsole
{
    internal class Book
    {
        public Dictionary<string, string> book_id { get; set; } = null!;
        public Dictionary<string, string> title { get; set; } = null!;
        public Dictionary<string, int> ratings { get; set; } = null!;
        public Dictionary<string, string> url { get; set; } = null!;
        public Dictionary<string, string> cover_image { get; set; } = null!;
    }
}
