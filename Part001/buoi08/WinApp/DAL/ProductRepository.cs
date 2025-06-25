using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository: BaseRepository
    {
        public ProductRepository(BookStoreContext context) : base(context)
        {
        }

        public int Add(Product obj)
        {
            context.Products.Add(obj);
            return context.SaveChanges();
        }
    }
}
