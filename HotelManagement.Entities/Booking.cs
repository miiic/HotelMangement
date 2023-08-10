namespace HotelManagement.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Room Room { get; set; }
    }
}
