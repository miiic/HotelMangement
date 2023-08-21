using HotelManagement.Domain.Entities;
using HotelManagement.Operations.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Operations.Queries
{
    public class GetHotelByNameQuery : IRequest<Hotel>
    {
        public GetHotelByNameQuery(string name)
        {
            Name = name;
        }

        internal string Name { get; private set; }
    }

    public class GetHotelByNameQueryHandler : IRequestHandler<GetHotelByNameQuery, Hotel>
    {
        private readonly IHotelManagementDbContext _context;

        public GetHotelByNameQueryHandler(IHotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Hotel> Handle(GetHotelByNameQuery request, CancellationToken ct)
        {
            return await _context.Hotels.FirstOrDefaultAsync(h => h.Name == request.Name, ct);
        }
    }
}
