
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.User.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.User;


namespace TravelBookingPortal.Application.Admin.User.Queries.GetAllAdmins
{
    public class GetAllAdminsQueryHandler(IUserRepository users, IMapper mapper) : IRequestHandler<GetAllAdminsQuery, IEnumerable<UsersDto>>
    {
        public async Task<IEnumerable<UsersDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var usersList = await users.GetAllAdmins();
            return mapper.Map<IEnumerable<UsersDto>>(usersList);
        }
    }
}
