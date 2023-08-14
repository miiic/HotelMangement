namespace HotelManagement.Domain.Entities
{
    public class Hotel
    {
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}