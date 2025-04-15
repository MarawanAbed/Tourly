using MediatR;


using System.Linq;
using TravelBookingPortal.Domain.Repositories.ItineraryIRepo;


namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class DeleteItineraryCommandHandler : IRequestHandler<DeleteItineraryCommand, bool>
    {
        private readonly IItineraryRepository _itineraryRepository;

        public DeleteItineraryCommandHandler(IItineraryRepository itineraryRepository)
        {
            _itineraryRepository = itineraryRepository;
        }

        public async Task<bool> Handle(DeleteItineraryCommand request, CancellationToken cancellationToken)
        {
            var itineraries = await _itineraryRepository.GetByUserIdAsync(request.UserId);

            var itinerary = itineraries?.FirstOrDefault(i => i.ItineraryId == request.ItineraryId);
            if (itinerary == null)
                return false;

            await _itineraryRepository.DeleteAsync(itinerary.ItineraryId);
            return true;
        }
    }
}
