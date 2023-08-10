using HotelManagement.Entities;
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
        public ActionResult<Hotel> Get(string name)
        {
            return Ok(_mediator.Send(new GetHotelByNameQuery(name)));
        }
    }
}
