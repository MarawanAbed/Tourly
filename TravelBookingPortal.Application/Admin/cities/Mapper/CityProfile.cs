

using AutoMapper;
using TravelBookingPortal.Application.Admin.cities.Commands;
using TravelBookingPortal.Application.Admin.cities.Dtos;
using TravelBookingPortal.Domain.Enitites.CityEnities;

namespace TravelBookingPortal.Application.Admin.cities.Mapper
{
    public class CityProfile : Profile
    {

        public CityProfile()
        {
            CreateMap<City,CreateCityCommand>();

            CreateMap<City, GetAllCitiesDto>();
        }
    }
}
