using HotelManagement.Domain.Entities;
using HotelManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Tests.Common.Data
{
    public class TestDatabaseFixture
    {
        const string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Database=Hotel_Management;Trusted_Connection=True;";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var hotel1 = new Hotel { Name = "Hotel1" };
                        var hotel2 = new Hotel { Name = "Hotel2" };

                        var room1 = new Room { Capacity = 1, Hotel = hotel1 };
                        var room2 = new Room { Capacity = 2, Hotel = hotel1 };
                        var room3 = new Room { Capacity = 3, Hotel = hotel1 };

                        var booking1 = new Booking { Arrival = new DateTime(2023, 1, 1), Departure = new DateTime(2023, 1, 4), Room = room1 };
                        var booking2 = new Booking { Arrival = new DateTime(2023, 1, 2), Departure = new DateTime(2023, 1, 5), Room = room2 };
                        var booking3 = new Booking { Arrival = new DateTime(2023, 1, 3), Departure = new DateTime(2023, 1, 6), Room = room3 };

                        context.AddRange(room1, room2, room3);
                        context.AddRange(hotel1, hotel2);
                        context.AddRange(booking1, booking2, booking3);

                        context.SaveChanges();
                    }
                    _databaseInitialized = true;
                }
            }
        }

        public HotelManagementDbContext CreateContext()
        {
            return new HotelManagementDbContext(
                new DbContextOptionsBuilder<HotelManagementDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
        }
    }
}