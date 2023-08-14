using HotelManagement.Domain.Entities;
using HotelManagement.Operations.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure
{
    public class HotelManagementDbContext : DbContext, IHotelManagementDbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelManagementDbContext).Assembly);
        }


    }
}
