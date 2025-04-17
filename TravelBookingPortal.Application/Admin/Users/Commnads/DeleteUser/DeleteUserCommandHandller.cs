

using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Users;

namespace TravelBookingPortal.Application.Admin.Users.Commnads.DeleteUser
{
    public class DeleteUserCommandHandller(IUsers users) : IRequestHandler<DeleteUserCommand>
    {
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await users.DeleteUser(request.UserId);
        }
    }
}
