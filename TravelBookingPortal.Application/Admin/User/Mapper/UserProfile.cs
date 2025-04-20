

using AutoMapper;
using TravelBookingPortal.Application.Admin.User.Dtos;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Admin.User.Mapper
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
