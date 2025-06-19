using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    public class ProductRepository
    {
        public static int Add(Product obj)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                context.Products.Add(obj);
                return context.SaveChanges();
            }    
        }
    }
}
