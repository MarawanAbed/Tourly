
using TravelBookingPortal.Application.UserProfile.Dtos;
using TravelBookingPortal.Domain.Enitites.PreferenceEnitites;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.UserProfile.Mapper
{
    public partial class UserProfile
    {
        public void UserProfileMapping()
        {

            CreateMap<ApplicationUser, UserProfileDto>()
             .ForMember(dest => dest.Preferences, opt => opt.MapFrom(src => src.Preferences));
            CreateMap<Preference, PreferenceDto>();
            CreateMap<PreferenceDto, Preference>();
        }

    }
}
