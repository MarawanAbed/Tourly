using MediatR;
using TravelBookingPortal.Application.Auth.Logout.Services;


namespace TravelBookingPortal.Application.Auth.logout.Commands
{
    public class LogoutCommandHandler(ILogoutService logoutService) : IRequestHandler<LogoutCommand>
    {

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            if (string.IsNullOrEmpty(userId))
        {
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }
            await logoutService.Logout(userId);
        }
    }
}
