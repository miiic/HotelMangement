﻿using HotelManagement.Domain.Models.Responses;
using HotelManagement.Entities;
using HotelManagement.Entities.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Commands
{
    public class MakeBookingCommand : IRequest<BookingResponse>
    {
        public MakeBookingCommand(int roomId, DateTime arrival, DateTime departure)
        {
            RoomId = roomId;
            Arrival = arrival;
            Departure = departure;
        }

        public int RoomId { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

    }

    public class MakeBookingCommandHandler : IRequestHandler<MakeBookingCommand, BookingResponse>
    {
        private readonly IHotelManagementDbContext _context;

        public MakeBookingCommandHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<BookingResponse> Handle(MakeBookingCommand request, CancellationToken ct)
        {
            var availableRoom = await _context.Rooms
               .Where(r => r.Id == request.RoomId)
               .Where(r => r.Bookings.All(b => b.Departure <= request.Arrival || b.Arrival >= request.Departure)).FirstOrDefaultAsync(ct);

            if (availableRoom != null)
            {
                var booking = new Booking
                {
                    Room = availableRoom,
                    Arrival = request.Arrival,
                    Departure = request.Departure
                };
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync(ct);
                return new BookingResponse { BookingSuccess = true };
            }
            return new BookingResponse { BookingSuccess = false };
        }
    }
}
