
using MediatR;
using TravelBookingPortal.Application.Admin.city.Dtos;

namespace TravelBookingPortal.Application.Admin.city.Queries
{
    public class GetAllCitiesQuery : IRequest<List<GetAllCitiesDto>>
    {
        public int? CityId { get; set; }

    }
}
