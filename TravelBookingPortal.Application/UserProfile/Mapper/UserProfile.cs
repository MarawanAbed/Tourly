

using AutoMapper;
using TravelBookingPortal.Application.UserProfile.Dtos;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.UserProfile.Mapper
{
    public class UserProfile : Profile
    {

        public UserProfile() 
        {
            CreateMap<ApplicationUser, UserProfileDto>()
             .ForMember(p => p.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(p => p.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
