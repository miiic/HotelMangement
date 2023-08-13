using HotelManagement.Entities;
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
                        context.AddRange(
                        new Hotel { Name = "Hotel1" },
                        new Hotel { Name = "Hotel2" });
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