using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookUrlRepository: BaseRepository
    {
        public BookUrlRepository(BookStoreContext context) : base(context)
        {
        }

        public int Add(List<BookUrl> list)
        {
            context.BookUrls.AddRange(list);
            return context.SaveChanges();
        }
    }
}
