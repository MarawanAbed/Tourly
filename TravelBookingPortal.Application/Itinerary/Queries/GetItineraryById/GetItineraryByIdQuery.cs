using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

namespace TravelBookingPortal.Application.Itinerary.Queries.GetItineraryById
{
    public class GetItineraryByIdQuery : IRequest<ItineraryDto>
    {
        public int ItineraryId { get; set; }
    }
}
