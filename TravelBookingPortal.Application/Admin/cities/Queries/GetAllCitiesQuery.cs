
using MediatR;
using TravelBookingPortal.Application.Admin.cities.Dtos;

namespace TravelBookingPortal.Application.Admin.cities.Queries
{
    public class GetAllCitiesQuery : IRequest<List<GetAllCitiesDto>>
    {
    }
}
