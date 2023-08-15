using HotelManagement.Domain.Entities;

namespace HotelManagement.Operations.Extensions
{
    internal static class RoomExtensions
    {
        internal static IQueryable<Room> WhereNonOverlappingAvailability
            (this IQueryable<Room> query, DateTime arrival, DateTime departure)
        {
            return query.Where(r => r.Bookings.All(b => b.Departure <= arrival || b.Arrival >= departure));
        }
    }
}
