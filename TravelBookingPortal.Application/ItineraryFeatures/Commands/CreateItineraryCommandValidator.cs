using FluentValidation;


namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class CreateItineraryCommandValidator : AbstractValidator<CreateItineraryCommand>
    {
        public CreateItineraryCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("Start Date must be before End Date.");
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("End Date must be in the future.");
        }
    }
}
