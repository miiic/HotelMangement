using FluentAssertions;
using HotelManagement.Operations.Queries;
using HotelManagement.Tests.Common.Data;
using Xunit;

namespace HotelManagement.Operations.Tests.Queries
{
    public class GetAvailableRoomsQueryTests : IClassFixture<TestDatabaseFixture>
    {
        public GetAvailableRoomsQueryTests(TestDatabaseFixture fixture) => Fixture = fixture;
        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public async Task Handle_ShouldReturnAvailableRooms_ForSingleOccupancyAndDateRange()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var arrivalDate = new DateTime(2023, 1, 1);
            var departureDate = new DateTime(2023, 1, 2);
            var occupancy = 1;

            var query = new GetAvailableRoomsQuery("Hotel1", occupancy, arrivalDate, departureDate);
            var handler = new GetAvailableRoomsQueryHandler(context);

            //Act
            var availableRooms = await handler.Handle(query, CancellationToken.None);

            //Assert
            availableRooms.Count.Should().Be(2);
            availableRooms.Select(r => r.Capacity).Should().AllSatisfy(c => c.Should().BeGreaterThanOrEqualTo(1));
        }

        [Fact]
        public async Task Handle_ShouldReturnAvailableRooms_ForDoubleOccupancyAndDateRange()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var arrivalDate = new DateTime(2023, 1, 1);
            var departureDate = new DateTime(2023, 1, 2);
            var occupancy = 2;

            var query = new GetAvailableRoomsQuery("Hotel1", occupancy, arrivalDate, departureDate);
            var handler = new GetAvailableRoomsQueryHandler(context);

            //Act
            var availableRooms = await handler.Handle(query, CancellationToken.None);

            //Assert
            availableRooms.Count.Should().Be(2);
            availableRooms.Select(r => r.Capacity).Should().AllSatisfy(c => c.Should().BeGreaterThanOrEqualTo(2));
        }

        [Fact]
        public async Task Handle_ShouldReturnAvailableRooms_ForTripleOccupancyAndDateRange()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var arrivalDate = new DateTime(2023, 1, 6);
            var departureDate = new DateTime(2023, 1, 10);
            var occupancy = 3;

            var query = new GetAvailableRoomsQuery("Hotel1", occupancy, arrivalDate, departureDate);
            var handler = new GetAvailableRoomsQueryHandler(context);

            //Act
            var availableRooms = await handler.Handle(query, CancellationToken.None);

            //Assert
            availableRooms.Count.Should().Be(1);
            availableRooms.Select(r => r.Capacity).Should().AllSatisfy(c => c.Should().BeGreaterThanOrEqualTo(3));
        }
    }
}
