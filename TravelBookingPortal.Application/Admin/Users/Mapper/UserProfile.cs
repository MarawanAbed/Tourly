

using AutoMapper;
using TravelBookingPortal.Application.Admin.Users.Dtos;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Admin.Users.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<ApplicationUser, UsersDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        }
    }
}
