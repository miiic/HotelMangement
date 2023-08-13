using HotelManagement.Entities;
using HotelManagement.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Operations.Commands
{
    public class MakeBookingCommand : IRequest<BookingResponse>
    {
        public MakeBookingCommand(string hotelName, int roomId, DateTime start, DateTime end)
        {
            
        }

        
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
            return null;
        }
    }
}
