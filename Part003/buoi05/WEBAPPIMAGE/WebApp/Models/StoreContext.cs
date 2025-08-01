using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; } = null!;
    }
}
