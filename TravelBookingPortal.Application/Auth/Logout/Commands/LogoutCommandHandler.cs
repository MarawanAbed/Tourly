using MediatR;
using TravelBookingPortal.Domain.Repositories.Auth;


namespace TravelBookingPortal.Application.Auth.logout.Commands
{
    public class LogoutCommandHandler(ILogoutRepoistory logoutRepoistory) : IRequestHandler<LogoutCommand>
    {
        async Task  IRequestHandler<LogoutCommand>.Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await logoutRepoistory.Logout();
        }
    }
}
