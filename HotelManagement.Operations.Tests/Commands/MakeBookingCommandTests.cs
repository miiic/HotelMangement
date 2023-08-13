using FluentAssertions;
using HotelManagement.Operations.Commands;
using HotelManagement.Tests.Common.Data;
using Xunit;

namespace HotelManagement.Operations.Tests.Commands
{
    public class MakeBookingCommandTests : IClassFixture<TestDatabaseFixture>
    {
        public MakeBookingCommandTests(TestDatabaseFixture fixture) => Fixture = fixture;
        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public async Task Handle_ShouldMakeBooking_WhenRoomIsAvailable()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var roomId = 1;
            var arrival = new DateTime(2023, 1, 4);
            var departure = new DateTime(2023, 1, 7);
            var command = new MakeBookingCommand(roomId, arrival, departure);
            var handler = new MakeBookingCommandHandler(context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            var debug = context.Bookings.ToList();
            context.Bookings.FirstOrDefault(b => 
                b.Room.Id == roomId && b.Arrival == arrival && b.Departure == departure).Should().NotBeNull();
            response.BookingSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_ShouldMakeBooking_WhenRoomIsNotAvailable()
        {
            //Arrange
            using var context = Fixture.CreateContext();
            var roomId = 1;
            var arrival = new DateTime(2023, 1, 1);
            var departure = new DateTime(2023, 1, 7);
            var command = new MakeBookingCommand(roomId, arrival, departure);
            var handler = new MakeBookingCommandHandler(context);

            //Act
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            var debug = context.Bookings.ToList();
            context.Bookings.FirstOrDefault(b =>
                b.Room.Id == roomId && b.Arrival == arrival && b.Departure == departure).Should().BeNull();
            response.BookingSuccess.Should().BeFalse();
        }
    }
}
