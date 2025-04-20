using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.UserProfile;
using TravelBookingPortal.Application.UserProfile.Dtos;

namespace TravelBookingPortal.Application.UserProfile.Queries
{
    public class GetUserProfileQueryHandler(IUserProfileRepository profileRepo, IMapper mapper) : IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user= await profileRepo.GetUserProfileAsync(request.UserId) ?? throw new Exception("User not found");
            var userDto = mapper.Map<UserProfileDto>(user);
            return userDto;

        }
    }
   
}
