

using MediatR;
using TravelBookingPortal.Application.Admin.city.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.City;

namespace TravelBookingPortal.Application.Admin.city.Queries
{
    public class GetAllCitiesQueryHandler(ICityRepository cities) : IRequestHandler<GetAllCitiesQuery, List<GetAllCitiesDto>>
    {
        public async Task<List<GetAllCitiesDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var citiesList = await cities.GetAllCities();
            return
                citiesList.Select(city => new GetAllCitiesDto
                {
                    CityId = city.CityId,
                    Name = city.Name,
                    ImageUrl = city.ImageUrl
                }).ToList();
        }
    }

}
