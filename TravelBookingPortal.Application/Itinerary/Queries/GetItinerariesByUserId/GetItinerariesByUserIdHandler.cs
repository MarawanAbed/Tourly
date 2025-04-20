using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;
using ItineraryEntities = TravelBookingPortal.Domain.Entites.Itinerary.ItineraryEntities;
namespace TravelBookingPortal.Application.Itinerary.Queries.GetItinerariesByUserId
{
    public class GetItinerariesByUserIdHandler(IItineraryRepository repository) : IRequestHandler<GetItinerariesByUserIdQuery, List<ItineraryEntities>>
    {
        public async Task<List<ItineraryEntities>> Handle(GetItinerariesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByUserIdAsync(request.UserId);
        }
    }
}
