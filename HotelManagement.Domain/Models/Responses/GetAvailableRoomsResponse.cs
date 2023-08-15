namespace HotelManagement.Domain.Models.Responses
{
    public class GetAvailableRoomsResponse
    {
        public ICollection<RoomResponseItem> AvailableRooms { get; set; }
    }

    public class RoomResponseItem
    {
        public int RoomId { get; set; }
        public int Capacity { get; set; }
        public string HotelName { get; set; }
    }
}
