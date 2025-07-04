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
        AttributeRepository attribute;
        ProductRepository product;
        SpecificationRepository specification;
        BookStoreContext context;

        public SiteProvider(BookStoreContext context)
        {
            this.context = context;
        }


        public AttributeRepository Attribute 
        {   
            get
            {
                if(attribute is null)
                    attribute = new AttributeRepository(context);
                return attribute;
            }
        }

        public ProductRepository Product 
        { 
            get
            {
                if(product is null)
                    product = new ProductRepository(context);
                return product;
            }
        }

        public SpecificationRepository Specification 
        { 
            get
            {
                if(specification is null)
                    specification = new SpecificationRepository(context);
                return specification;
            }
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
