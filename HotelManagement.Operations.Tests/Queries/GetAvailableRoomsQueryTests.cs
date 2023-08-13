using HotelManagement.Entities;
using HotelManagement.Operations.Queries;
using NSubstitute;
using Xunit;

namespace HotelManagement.Operations.Tests.Queries
{
    public class GetAvailableRoomsQueryTests
    {
        [Fact]
        public void Handle_ShouldReturnAvailableRooms_ForDateRange()
        {
            //Arrange
            var arrivalDate = new DateTime(2023, 1, 1);
            var departureDate = new DateTime(2023, 1, 1);
            var occupancy = 1;

            var query = new GetAvailableRoomsQuery("Test Hotel", occupancy, arrivalDate, departureDate);
            var context = Substitute.For<IHotelManagementDbContext>();
            var handler = new GetAvailableRoomsQueryHandler(context);

            //Act


            //Assert
        }
    }
}
