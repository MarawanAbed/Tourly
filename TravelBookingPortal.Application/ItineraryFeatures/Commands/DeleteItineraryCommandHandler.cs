using MediatR;
using TravelBookingPortal.Domain.Repositories.ItineraryRepo;
using System.Threading;
using System.Threading.Tasks;

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
            var itinerary = await _itineraryRepository.GetByIdAsync(request.ItineraryId);
            if (itinerary == null)
                return false;

            await _itineraryRepository.DeleteAsync(request.ItineraryId);
            return true;
        }
    }
}
