

using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Users;

namespace TravelBookingPortal.Application.Admin.Users.Commnads
{
    public class ChangeUsersRoleHandler(IUsers users ) : IRequestHandler<ChangeUsersRoleCommnad>
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
