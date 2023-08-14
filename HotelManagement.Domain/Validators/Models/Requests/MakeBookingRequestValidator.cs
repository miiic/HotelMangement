using FluentValidation;
using HotelManagement.Domain.Models.Requests;

namespace HotelManagement.Domain.Validators.Models.Requests
{
    public class MakeBookingRequestValidator : AbstractValidator<MakeBookingRequest>
    {
        public MakeBookingRequestValidator()
        {
            //Properties cannot be null in a booking request
            RuleFor(x => x.Arrival).NotNull();
            RuleFor(x => x.Departure).NotNull();
            RuleFor(x => x.RoomId).GreaterThan(0);

            //Arrival date must be before departure date
            RuleFor(x => x.Arrival).LessThan(x => x.Departure).
                WithMessage("Arrival date must be before departure date");

            //Departure date must come after arrival date
            RuleFor(x => x.Departure).GreaterThan(x => x.Arrival).
                WithMessage("Departure date must be after arrival date");
        }
    }
}
