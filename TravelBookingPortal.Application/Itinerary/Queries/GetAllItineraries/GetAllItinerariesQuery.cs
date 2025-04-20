using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

namespace TravelBookingPortal.Application.Itinerary.Queries.GetAllItineraries
{
    public class GetAllItinerariesQuery : IRequest<List<ItineraryDto>>
    {
    }
}
