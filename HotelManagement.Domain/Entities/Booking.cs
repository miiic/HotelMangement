namespace HotelManagement.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
