using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Models.Responses;
using HotelManagement.Operations.Extensions;
using HotelManagement.Operations.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Queries
{
    public class GetAvailableRoomsQuery : IRequest<GetAvailableRoomsResponse>
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

    public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, GetAvailableRoomsResponse>
    {
        private readonly IHotelManagementDbContext _context;

        public GetAvailableRoomsQueryHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<GetAvailableRoomsResponse> Handle(GetAvailableRoomsQuery request, CancellationToken ct)
        {
            var availableRooms = await _context.Rooms
               .Where(r =>
                    (r.Hotel.Name != null && r.Hotel.Name == request.HotelName) &&
                    r.Capacity >= request.Occupancy
                )
               .WhereNonOverlappingAvailability(request.Arrival, request.Departure)
               .Select(r => new RoomResponseItem
               {
                   RoomId = r.Id,
                   Capacity = r.Capacity,
                   HotelName = r.Hotel.Name,
               }).ToListAsync(ct);

            return new GetAvailableRoomsResponse
            {
                AvailableRooms = availableRooms
            };
        }
    }
}
