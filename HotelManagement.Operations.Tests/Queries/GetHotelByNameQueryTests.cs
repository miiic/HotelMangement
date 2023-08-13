using FluentAssertions;
using HotelManagement.Operations.Queries;
using HotelManagement.Tests.Common.Data;
using Xunit;

namespace HotelManagement.Operations.Tests.Queries
{
    public class GetHotelByNameQueryTests : IClassFixture<TestDatabaseFixture>
    {
        public GetHotelByNameQueryTests(TestDatabaseFixture fixture) => Fixture = fixture;
        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public async Task Handle_ShouldReturnHotel_WhenHotelNameMatches()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var hotelName = "Hotel1";
            var query = new GetHotelByNameQuery(hotelName);
            var handler = new GetHotelByNameQueryHandler(context);

            //Act
            var hotel = await handler.Handle(query, CancellationToken.None);

            //Assert
            hotel.Name.Should().Be(hotelName);
        }

    }
}
