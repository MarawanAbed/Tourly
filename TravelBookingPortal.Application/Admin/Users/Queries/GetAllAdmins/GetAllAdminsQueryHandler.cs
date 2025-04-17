
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Users.Dtos;
using TravelBookingPortal.Application.Admin.Users.Queries.GetAllAdmins;
using TravelBookingPortal.Domain.Repositories.Admin.Users;

namespace TravelBookingPortal.Application.Admin.Users.Queries.GetAllUsers
{
    public class GetAllAdminsQueryHandler(IUsers users, IMapper mapper) : IRequestHandler<GetAllAdminsQuery, IEnumerable<UsersDto>>
    {
        public async Task<IEnumerable<UsersDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var usersList = await users.GetAllAdmins();
            return mapper.Map<IEnumerable<UsersDto>>(usersList);
        }
    }
}
