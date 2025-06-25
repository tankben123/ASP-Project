using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AttributeRepository:BaseRepository
    {
        public AttributeRepository(BookStoreContext context) : base(context)
        {
        }

        public int Add(Attribute obj)
        {
            context.Attributes.Add(obj);
            return context.SaveChanges();
        }
    }
}
