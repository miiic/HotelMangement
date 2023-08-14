using HotelManagement.Entities.Entities;
using HotelManagement.Operations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult<Hotel> Get(int roomId, DateTime arrival, DateTime departure, CancellationToken ct = default)
        {
            return Ok(_mediator.Send(new MakeBookingCommand(roomId, arrival, departure), ct));
        }
    }
}
