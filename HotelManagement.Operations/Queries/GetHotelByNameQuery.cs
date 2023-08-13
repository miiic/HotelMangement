using HotelManagement.Entities;
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

        public string Name { get; set; }
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
            return await _context.Hotels
                .Where(h => h.Name == request.Name).FirstOrDefaultAsync(ct);
        }
    }
}
