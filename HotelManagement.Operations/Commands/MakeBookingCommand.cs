﻿using HotelManagement.Domain.Entities;
using HotelManagement.Domain.Models.Responses;
using HotelManagement.Operations.Extensions;
using HotelManagement.Operations.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Commands
{
    public class MakeBookingCommand : IRequest<MakeBookingResponse>
    {
        public MakeBookingCommand(int roomId, DateTime arrival, DateTime departure)
        {
            RoomId = roomId;
            Arrival = arrival;
            Departure = departure;
        }

        internal int RoomId { get; private set; }
        internal DateTime Arrival { get; private set; }
        internal DateTime Departure { get; private set; }

    }

    public class MakeBookingCommandHandler : IRequestHandler<MakeBookingCommand, MakeBookingResponse>
    {
        private readonly IHotelManagementDbContext _context;

        public MakeBookingCommandHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<MakeBookingResponse> Handle(MakeBookingCommand request, CancellationToken ct)
        {
            var availableRoom = await _context.Rooms
               .Where(r => r.Id == request.RoomId)
               .WhereNonOverlappingAvailability(request.Arrival, request.Departure)
               .FirstOrDefaultAsync(ct);

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
                return new MakeBookingResponse { BookingSuccess = true };
            }
            return new MakeBookingResponse { BookingSuccess = false };
        }
    }
}
