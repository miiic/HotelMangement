using HotelManagement.Domain.Models.Responses;
using HotelManagement.Operations.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Queries
{
    public class GetBookingByIdQuery : IRequest<GetBookingResponse>
    {
        public GetBookingByIdQuery(int bookingId)
        {
            BookingId = bookingId;
        }

        public int BookingId { get; set; }
    }

    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, GetBookingResponse>
    {

        private readonly IHotelManagementDbContext _context;

        public GetBookingByIdQueryHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public Task<GetBookingResponse> Handle(GetBookingByIdQuery request, CancellationToken ct)
        {
            return _context.Bookings.Select(b => new GetBookingResponse
                {
                    BookingId = b.Id,
                    RoomCapacity = b.Room.Capacity,
                    Arrival = b.Arrival,
                    Departure = b.Departure,
                    HotelName = b.Room.Hotel.Name
                }).FirstOrDefaultAsync(b => b.BookingId == request.BookingId, ct);
        }
    }
}
