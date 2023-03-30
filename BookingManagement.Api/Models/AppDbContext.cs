using Microsoft.EntityFrameworkCore;

namespace BookingManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<BookingEvent> BookingEvents { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ordersdb;Username=postgres;Password=190373");
        }
    }
}
