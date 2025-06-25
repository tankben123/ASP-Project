using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SpecificationRepository:BaseRepository
    {
        public SpecificationRepository(BookStoreContext context) : base(context)
        {
        }

        public int Add(List<Specification> obj)
        {
            context.Specifications.AddRange(obj);
            return context.SaveChanges();
        }
    }
}
