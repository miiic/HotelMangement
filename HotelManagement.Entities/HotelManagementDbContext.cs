using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Entities
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; }
        public DbSet<Booking> Bookings { get; }
        public DbSet<Room> Rooms { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelManagementDbContext).Assembly);
        }


    }
}
