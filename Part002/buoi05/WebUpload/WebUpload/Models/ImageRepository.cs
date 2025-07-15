namespace WebUpload.Models
{
    public class ImageRepository
    {
        StoreContext context;
        public ImageRepository(StoreContext context) => this.context = context;

        public List<Image> GetImages()
        {
            return context.Images.ToList();
        }

        public int Add(Image obj)
        {
            context.Images.Add(obj);
            return context.SaveChanges();
        }

        public Image? GetImage(int id)
        {
            return context.Images.Find(id);
        }
    }
}
