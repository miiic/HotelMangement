using HotelManagement.Domain.Entities;
using HotelManagement.Operations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult<Hotel> Get(string name, CancellationToken ct = default)
        {
            return Ok(_mediator.Send(new GetHotelByNameQuery(name), ct));
        }
    }
}
