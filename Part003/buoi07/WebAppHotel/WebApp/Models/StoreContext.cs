using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<State> States { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Transition> Transitions { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transition>().HasNoKey();
            modelBuilder.Entity<Stock>().HasNoKey();

            //modelBuilder.Entity<Transition>().
            //    HasOne(t => t.FromState)
            //    .WithMany(s => s.Transitions)
            //    .HasForeignKey(t => t.FromStateId);
        }
    }

}
