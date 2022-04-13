using Microsoft.EntityFrameworkCore;
using OrderApi.DAL.EntitiesConfigurations;
using OrderApi.Models;

namespace OrderApi.DAL
{
    public class OrderApiContext : DbContext
    {
        public OrderApiContext() { }

        public OrderApiContext(DbContextOptions<OrderApiContext> options)
            : base(options) { }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PostTerminal> Terminals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=Test;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTerminalTypeConfiguration).Assembly);
        }
    }
}
