using HotelManagement.Domain.Entities;
using HotelManagement.Operations.Interfaces;
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

        public GetBookingByIdQueryHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken ct)
        {
            //.Include(b => b.Room) use DTO to decouple this and avoid cylical reference
            return _context.Bookings.FirstOrDefaultAsync(b => b.Id == b.Id, ct);
        }
    }
}
