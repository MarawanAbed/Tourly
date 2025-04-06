
using MediatR;
using TravelBookingPortal.Application.CityLogic.Dtos;

namespace TravelBookingPortal.Application.CityLogic.Queries.Models
{
   public class GetCitiesListQuery :IRequest<IEnumerable<GetCitiesDTO>>
    {
        

    }
    
}
