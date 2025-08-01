namespace WebApp.Models
{
    public class SiteProvider
    {
        StoreContext context;
        private ImageRepository? _image;

        public SiteProvider(StoreContext context)
        {
            this.context = context;
        }


        public ImageRepository Image
        {
            get
            {
                if (_image is null)
                    _image = new ImageRepository(context);
                return _image;
            }
        }

    }
}
