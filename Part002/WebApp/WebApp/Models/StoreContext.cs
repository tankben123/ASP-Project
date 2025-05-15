using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options) { }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
