

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotels.Commands;
using TravelBookingPortal.Application.Admin.Hotels.Dtos;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Application.Admin.Hotels.Mapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, CreateHotelCommand>();

            CreateMap<Hotel , GetAllHotelsDto>();
        }
    }
}
