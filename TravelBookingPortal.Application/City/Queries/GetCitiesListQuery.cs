
using MediatR;
using TravelBookingPortal.Application.City.Dtos;

namespace TravelBookingPortal.Application.City.Queries
{
    public class GetCitiesListQuery : IRequest<IEnumerable<GetCitiesDTO>>
    {


    }

}
