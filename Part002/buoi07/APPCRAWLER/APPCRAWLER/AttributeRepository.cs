using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    public class AttributeRepository
    {
        public static int Add(Attribute obj)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                context.Attributes.Add(obj);
                return context.SaveChanges();
            }
        }
    }
}
