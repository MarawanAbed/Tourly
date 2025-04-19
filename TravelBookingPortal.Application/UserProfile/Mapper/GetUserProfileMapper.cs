
using TravelBookingPortal.Application.UserProfile.Dtos;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.UserProfile.Mapper
{
    public partial class UserProfile
    {
        public void UserProfileMapping()
        {

            CreateMap<ApplicationUser, UserProfileDto>()
             .ForMember(p => p.Email, opt => opt.MapFrom(src=>src.Email))
             .ForMember(p => p.UserName, opt => opt.MapFrom(src=>src.UserName));
        }

    }
}
