using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPCRAWLER
{
    public class BookStoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Attribute> Attributes { get; set; } = null!;

        public DbSet<Specification> Specifications { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Specification>().HasKey(p => new {
                p.ProductId,
                p.AttributeId
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=172.168.5.160,10100;Database=BookStore;User Id=fa11;Password=Toan@2023");
        }
    }
}
