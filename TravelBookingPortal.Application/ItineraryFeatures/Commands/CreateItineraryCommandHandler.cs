using MediatR;
using TravelBookingPortal.Domain.Enitites.ItineraryEntities;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;

namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class CreateItineraryCommandHandler : IRequestHandler<CreateItineraryCommand, int>
    {
        private readonly IItineraryRepository _itineraryRepository;

        public CreateItineraryCommandHandler(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public async Task<int> Handle(CreateItineraryCommand request, CancellationToken cancellationToken)
        {
            var itinerary = new Itinerary
            {
                UserId = request.UserId,
                Title = request.Title,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Notes = request.Notes
            };

            await _itineraryRepository.AddAsync(itinerary);
            return itinerary.ItineraryId;
        }
    }
}
