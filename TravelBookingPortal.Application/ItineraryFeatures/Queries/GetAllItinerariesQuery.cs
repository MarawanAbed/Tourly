using MediatR;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetAllItinerariesQuery : IRequest<List<ItineraryDto>>
    {
    }
}
