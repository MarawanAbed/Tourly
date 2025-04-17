
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.cities.Dtos;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;

namespace TravelBookingPortal.Application.Admin.cities.Queries
{
    public class GetAllCitiesQueryHandler (ICities cities): IRequestHandler<GetAllCitiesQuery, List<GetAllCitiesDto>>
    {
        public async  Task<List<GetAllCitiesDto>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var citiesList = await cities.GetAllCities();
            return
                citiesList.Select(city => new GetAllCitiesDto
                {
                    Name = city.Name,
                    ImageUrl = city.ImageUrl
                }).ToList();
        }
    }

}
