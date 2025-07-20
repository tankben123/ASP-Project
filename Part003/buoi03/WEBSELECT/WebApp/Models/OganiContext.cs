using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class OganiContext:DbContext
    {
        public OganiContext(DbContextOptions options):base(options) 
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }

    }
}
