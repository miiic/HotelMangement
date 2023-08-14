using HotelManagement.Entities;
using HotelManagement.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Queries
{
    public class GetBookingByIdQuery : IRequest<Booking>
    {
        public GetBookingByIdQuery(int bookingId)
        {
            BookingId = bookingId;
        }

        public int BookingId { get; set; }
    }

    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
    {
        private readonly IHotelManagementDbContext _context;

        public Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken ct)
        {
            return _context.Bookings.FirstOrDefaultAsync(b => b.Id == b.Id, ct);
        }
    }
}
