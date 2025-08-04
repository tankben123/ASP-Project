using System.Reflection.Metadata.Ecma335;

namespace WebApp.Models
{
    public class SiteProvider
    {
        StoreContext context;

        public SiteProvider(StoreContext context)
        {
            this.context = context;
        }

        ImageRepository _image;
        CategoryRepository _repository;

        public ImageRepository Image
        {
            get
            {
                if (_image != null)
                    return _image;

                _image = new ImageRepository(context);
                return _image;
            }
        }

        public CategoryRepository Category
        {
            get
            {
                if (_repository != null)
                    return _repository;

                _repository = new CategoryRepository(context);
                return _repository;
            }
        }

    }
}
