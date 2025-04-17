
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Users.Dtos;
using TravelBookingPortal.Domain.Repositories.Admin.Users;

namespace TravelBookingPortal.Application.Admin.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUsers users, IMapper mapper) : IRequestHandler<GetAllUsersQuery, IEnumerable<UsersDto>>
    {
        public async Task<IEnumerable<UsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersList = await users.GetAllUsers();
            return mapper.Map<IEnumerable<UsersDto>>(usersList);
        }
    }
}
