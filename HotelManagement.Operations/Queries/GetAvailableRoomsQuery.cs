using HotelManagement.Entities;
using HotelManagement.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Queries
{
    public class GetAvailableRoomsQuery : IRequest<ICollection<Room>>
    {
        public GetAvailableRoomsQuery(string hotelName, int occupancy, DateTime arrival, DateTime departure)
        {
            HotelName = hotelName;
            Occupancy = occupancy;
            Arrival = arrival;
            Departure = departure;
        }

        public string HotelName { get; set; }
        public int Occupancy { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }

    public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, ICollection<Room>>
    {
        private readonly IHotelManagementDbContext _context;

        public GetAvailableRoomsQueryHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Room>> Handle(GetAvailableRoomsQuery request, CancellationToken ct)
        {
            return await _context.Rooms
               .Where(r =>
                    r.Hotel.Name == request.HotelName &&
                    r.Capacity >= request.Occupancy
                )
               .Where(r => r.Bookings.All(b => b.Departure <= request.Arrival || b.Arrival >= request.Departure)).ToListAsync(ct);
        }
    }
}
