using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    public class SpecificationRepository
    {
        public static int Add(List<Specification> obj)
        {
            using (BookStoreContext context = new BookStoreContext())
            {
                context.Specifications.AddRange(obj);
                return context.SaveChanges();
            }
        }
    }
}
