namespace WebApp.Models
{
    public class BrandRepository:BaseRepository
    {
        public BrandRepository(StoreContext context):base(context)
        {
        }

        public List<Brand> GetBrands()
        {
            return context.Brands.ToList();
        }
    }
}
