

using AutoMapper;
using TravelBookingPortal.Application.Auth.Register.Commands;
using TravelBookingPortal.Domain.Entites.User;

namespace TravelBookingPortal.Application.Auth.Register.Mapper
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<RegisterCommand, ApplicationUser>()
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom<ImageUrlResolver>());
        }


    }
}
