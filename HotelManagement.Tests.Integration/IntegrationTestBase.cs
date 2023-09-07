using Api.Hotel.Management;
using HotelManagement.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagement.Tests.Integration
{
    public class IntegrationTestBase : IClassFixture<HotelManagementFactory<Program, HotelManagementDbContext>>
    {
        public readonly HotelManagementFactory<Program, HotelManagementDbContext> Factory;
        public readonly HotelManagementDbContext Context;

        public IntegrationTestBase(HotelManagementFactory<Program, HotelManagementDbContext> factory)
        {
            Factory = factory;
            var scope = factory.Services.CreateScope();
            Context = scope.ServiceProvider.GetRequiredService<HotelManagementDbContext>();
        }
    }
}
