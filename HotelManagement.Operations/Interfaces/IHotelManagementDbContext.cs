using HotelManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Interfaces
{
    public interface IHotelManagementDbContext
    {

        public DbSet<Hotel> Hotels { get; }
        public DbSet<Booking> Bookings { get; }
        public DbSet<Room> Rooms { get; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
