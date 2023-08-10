using HotelManagement.Entities;
using MediatR;

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

        public Task<Hotel> Handle(GetHotelByNameQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
