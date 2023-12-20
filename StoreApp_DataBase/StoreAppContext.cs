using Microsoft.EntityFrameworkCore;
using StoreApp_DataBase.Entities;

namespace StoreApp_DataBase
{
    public class StoreAppContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Provider> Provider { get; set; }

        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasIndex(o => new { o.Number, o.ProviderId })
                .IsUnique();
        }
    }
}
