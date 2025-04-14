using MediatR;
using TravelBookingPortal.Domain.Repositories.AuthRepo;


namespace TravelBookingPortal.Application.Auth.logout.Commands
{
    public class LogoutCommandHandler(ILogoutRepository logoutRepoistory) : IRequestHandler<LogoutCommand>
    {
        async Task  IRequestHandler<LogoutCommand>.Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await logoutRepoistory.Logout();
        }
    }
}
