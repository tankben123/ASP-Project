using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppIdentityCore.Models
{
    public class BookStoreContext:IdentityDbContext
    {
        public BookStoreContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}
