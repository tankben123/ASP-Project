using Microsoft.EntityFrameworkCore;

namespace UploadApp.Models
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Upload> Uploads { get; set; }
    }
}
