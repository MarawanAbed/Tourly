using MediatR;
using TravelBookingPortal.Domain.Entites.Itinerary;

namespace TravelBookingPortal.Application.Itinerary.Queries.GetItinerariesByUserId
{
    public class GetItinerariesByUserIdQuery : IRequest<List<ItineraryEntities>>
    {
        public string UserId { get; set; }

        public GetItinerariesByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
