using HotelManagement.Entities.Entities;
using HotelManagement.Operations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<Hotel> Get(string hotelName, int occupancy, DateTime arrival, DateTime departure, CancellationToken ct = default)
        {
            return Ok(_mediator.Send(new GetAvailableRoomsQuery(hotelName, occupancy, arrival, departure), ct));
        }
    }
}
