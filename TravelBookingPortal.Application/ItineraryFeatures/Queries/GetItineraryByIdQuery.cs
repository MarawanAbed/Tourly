using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetItineraryByIdQuery : IRequest<ItineraryDto> 
    {
        public int ItineraryId { get; set; } 
    }
}
