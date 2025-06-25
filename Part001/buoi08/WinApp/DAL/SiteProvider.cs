using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SiteProvider
    {

        BookUrlRepository bookUrl;
        BookStoreContext context;

        public SiteProvider(BookStoreContext context)
        {
            this.context = context;
            this.bookUrl = bookUrl;
        }

        public BookUrlRepository BookUrl 
        { 
            get
            {
                if(bookUrl is null)
                    bookUrl = new BookUrlRepository(context);

                return bookUrl;
            }
        }
    }
}
