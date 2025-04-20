

using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.User;

namespace TravelBookingPortal.Application.Admin.User.Commnads.ChangeRole
{
    public class ChangeUsersRoleHandler(IUserRepository users) : IRequestHandler<ChangeUsersRoleCommnad>
    {
        public async Task Handle(ChangeUsersRoleCommnad request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                throw new ArgumentException("UserId cannot be null or empty", nameof(request.UserId));
            }
            await users.ChangeUserRole(request.UserId);
        }
    }
}
