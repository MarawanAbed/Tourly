using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Itinerary;


namespace TravelBookingPortal.Application.Itinerary.Commands.DeleteItinerary
{
    public class DeleteItineraryCommandHandler(IItineraryRepository itineraryRepository) : IRequestHandler<DeleteItineraryCommand, bool>
    {
        public async Task<bool> Handle(DeleteItineraryCommand request, CancellationToken cancellationToken)
        {
            var itineraries = await itineraryRepository.GetByUserIdAsync(request.UserId);

            var itinerary = itineraries?.FirstOrDefault(i => i.ItineraryId == request.ItineraryId);
            if (itinerary == null)
                return false;

            await itineraryRepository.DeleteAsync(itinerary.ItineraryId);
            return true;
        }
    }
}
