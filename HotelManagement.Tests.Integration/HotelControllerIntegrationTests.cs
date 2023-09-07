using Api.Hotel.Management;
using FluentAssertions;
using HotelManagement.Domain.Entities;
using HotelManagement.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace HotelManagement.Tests.Integration
{
    public class HotelControllerIntegrationTests : IntegrationTestBase
    {
        private readonly HotelManagementFactory<Program, HotelManagementDbContext> _factory;

        public HotelControllerIntegrationTests(HotelManagementFactory<Program, HotelManagementDbContext> factory) : base(factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test1()
        {
            var client = _factory.CreateClient();

            //Arrange
            var hotel1 = new Hotel { Name = "Hotel1" };
            await Context.AddAsync(hotel1);
            await Context.SaveChangesAsync();

            //Act
            var response = await client.GetAsync("/hotel/?name=Hotel1");

            //Assert
            var hotel = await response.Content.ReadFromJsonAsync<Hotel>();
            hotel?.Name.Should().Be("Hotel1");
        }
    }
}