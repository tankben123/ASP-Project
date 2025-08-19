using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey("IdentificationNumber");




            base.OnModelCreating(modelBuilder);

        }
    }
}
