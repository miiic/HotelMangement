namespace HotelManagement.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Hotel Hotel { get; set; }
    }
}
