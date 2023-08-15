namespace HotelManagement.Domain.Models.Responses
{
    public class GetBookingResponse
    {
        public int BookingId { get; set; }
        public string HotelName { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int RoomCapacity { get; set; }
    }
}
