
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.City.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.City;

namespace TravelBookingPortal.Application.City.Queries
{
    public class GetCitiesListQueryHandler(ICityRepository cityRepository, IMapper mapper) : IRequestHandler<GetCitiesListQuery, IEnumerable<GetCitiesDTO>>
    {
        public async Task<IEnumerable<GetCitiesDTO>> Handle(GetCitiesListQuery request, CancellationToken cancellationToken)
        {
            var CityList = await cityRepository.GetAllCitiesAsync();
            var cityListMapper = mapper.Map<IEnumerable<GetCitiesDTO>>(CityList);
            return cityListMapper;
        }
    }
}
