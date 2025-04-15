using MediatR;
using TravelBookingPortal.Domain.Repositories.AuthRepo;


namespace TravelBookingPortal.Application.Auth.logout.Commands
{
    public class LogoutCommandHandler(ILogoutRepository logoutRepoistory) : IRequestHandler<LogoutCommand>
    {

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            if (string.IsNullOrEmpty(userId))
        {
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }
            await logoutRepoistory.Logout(userId);
        }
    }
}
