using AutoMapper;
using MediatR;

using TravelBookingPortal.Application.UserProfile.Dtos;
using TravelBookingPortal.Domain.Repositories.UserProfile;

namespace TravelBookingPortal.Application.UserProfile.Queries
{
    public class GetUserProfileQueryHandler:IRequestHandler<GetUserProfileQuery, UserProfileDto>
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IMapper _mapper;

        public GetUserProfileQueryHandler(IProfileRepo profileRepo, IMapper mapper)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
        }
        public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user= await _profileRepo.GetUserProfileAsync(request.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
           var userDto = _mapper.Map<UserProfileDto>(user);
            return userDto;

        }
    }
   
}
