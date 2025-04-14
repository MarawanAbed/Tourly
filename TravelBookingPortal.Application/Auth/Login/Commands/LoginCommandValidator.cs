

using FluentValidation;
using TravelBookingPortal.Application.Auth.Login.Response;

namespace TravelBookingPortal.Application.Auth.Login.Commands
{
    public class LogoutCommandValidator : AbstractValidator<LoginCommand>
    {
        public LogoutCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty();
        
        }
    }
}
