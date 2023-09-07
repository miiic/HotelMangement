using Api.Hotel.Management;
using DotNet.Testcontainers.Builders;
using HotelManagement.Domain.Entities;
using HotelManagement.Infrastructure;
using HotelManagement.Operations.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;

namespace HotelManagement.Tests.Integration
{
    public class HotelManagementFactory<TProgram, TDbContext> : WebApplicationFactory<TProgram>, IAsyncLifetime
        where TProgram : class where TDbContext : DbContext
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder().Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Remove AppDbContext
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HotelManagementDbContext>));
                if (descriptor != null) services.Remove(descriptor);

                // Add DB context pointing to test container
                services.AddDbContext<HotelManagementDbContext>(options => { options.UseSqlServer(_dbContainer.GetConnectionString()); });

                // Ensure schema gets created
                var serviceProvider = services.BuildServiceProvider();

                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<HotelManagementDbContext>();
                context.Database.EnsureCreated();
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _dbContainer.DisposeAsync();
        }
    }
}
