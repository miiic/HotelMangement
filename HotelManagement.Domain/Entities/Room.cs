﻿namespace HotelManagement.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; protected set; }
        public Hotel Hotel { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
