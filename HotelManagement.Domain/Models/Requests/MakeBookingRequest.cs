namespace HotelManagement.Domain.Models.Requests
{
    public class MakeBookingRequest
    {
        public int RoomId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}
