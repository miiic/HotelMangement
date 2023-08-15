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
        public async Task<ActionResult<Hotel>> Get(string name, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetHotelByNameQuery(name), ct);
            return Ok(result);
        }
    }
}
