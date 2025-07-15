using Microsoft.EntityFrameworkCore;

namespace WebUpload.Models
{
    public class StoreContext:DbContext
    {
       public StoreContext(DbContextOptions options):base(options) { }

        public DbSet<Image> Images { get; set; } = null!;
    }
}
