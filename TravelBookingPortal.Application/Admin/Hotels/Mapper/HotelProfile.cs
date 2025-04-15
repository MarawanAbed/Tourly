

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Create;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Update;
using TravelBookingPortal.Application.Admin.Hotels.Dtos;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Application.Admin.Hotels.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<CreateHotelCommand,
                Hotel>()
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom<CreateImageUrlResolver>());
            CreateMap<Hotel, GetAllHotelsDto>();

            CreateMap<UpdateHotelCommand, Hotel>()
                .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom<UpdateImageUrlResolver>());
        }
    }
}
