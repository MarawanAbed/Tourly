
using AutoMapper;
using TravelBookingPortal.Application.City.Dtos;
using TravelBookingPortal.Domain.Entites.City;

namespace TravelBookingPortal.Application.City.Mapper
{
    public partial class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntities, GetCitiesDTO>();
        }
    }
}
