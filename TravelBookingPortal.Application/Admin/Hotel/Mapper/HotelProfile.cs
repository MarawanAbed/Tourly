

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotel.Commands.Create;
using TravelBookingPortal.Application.Admin.Hotel.Commands.Update;
using TravelBookingPortal.Application.Admin.Hotel.Dtos;
using TravelBookingPortal.Domain.Entites.Hotel;

namespace TravelBookingPortal.Application.Admin.Hotel.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<CreateHotelCommand,
                HotelEntities>()
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom<CreateImageUrlResolver>());
            CreateMap<HotelEntities, GetAllHotelsDto>();

            CreateMap<UpdateHotelCommand, HotelEntities>()
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom<UpdateImageUrlResolver>());
        }
    }
}
