using MediatR;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Application.ItineraryFeatures.Queries
{
    public class GetItinerariesByUserIdHandler : IRequestHandler<GetItinerariesByUserIdQuery, List<Itinerary>>
    {
        private readonly IItineraryRepository _repository;

        public GetItinerariesByUserIdHandler(IItineraryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Itinerary>> Handle(GetItinerariesByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByUserIdAsync(request.UserId);
        }
    }
}
