using FluentValidation;


namespace TravelBookingPortal.Application.UserProfile.Commands
{
    public class UpdateUserProfileValidator: AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required.");
            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Image is required.");
            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("State is required.");
            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required.");
            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("Street is required.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User name is required.")
                .MinimumLength(3)
                .WithMessage("User name must be at least 3 characters long.");
        }
    }
}
