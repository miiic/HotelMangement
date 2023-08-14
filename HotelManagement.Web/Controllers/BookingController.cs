using FluentValidation;
using HotelManagement.Domain.Models.Requests;
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
        private readonly IValidator<MakeBookingRequest> _validator;


        public BookingController(IMediator mediator, IValidator<MakeBookingRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> Get([FromBody] MakeBookingRequest request, CancellationToken ct = default)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            var result = await _mediator.Send(new MakeBookingCommand(request.RoomId, request.Arrival, request.Departure), ct);
            return Ok(result);
        }
    }
}
