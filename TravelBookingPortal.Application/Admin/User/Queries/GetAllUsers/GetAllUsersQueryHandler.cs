
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.User.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.User;


namespace TravelBookingPortal.Application.Admin.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository users, IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<UsersDto>>
    {
        public async Task<IEnumerable<UsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await users.GetAllUsers();
            return mapper.Map<IEnumerable<UsersDto>>(usersList);
        }
    }
}
