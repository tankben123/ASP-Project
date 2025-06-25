using DAL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BookStoreContext: DbContext
    {
        string connectionString = "Server=172.168.5.160,10100;Database=BookStore;User Id=fa11;Password=Toan@2023";
        public BookStoreContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
        }

        public DbSet<BookUrl> BookUrls { get; set; } = null!;

        public DbSet<Attribute> Attributes { get; set; } = null!;


        public DbSet<Specification> Specifications { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
