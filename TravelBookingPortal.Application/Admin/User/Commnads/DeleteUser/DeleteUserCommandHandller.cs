

using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.User;


namespace TravelBookingPortal.Application.Admin.User.Commnads.DeleteUser
{
    public class DeleteUserCommandHandller(IUserRepository users) : IRequestHandler<DeleteUserCommand>
    {
        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await users.DeleteUser(request.UserId);
        }
    }
}
