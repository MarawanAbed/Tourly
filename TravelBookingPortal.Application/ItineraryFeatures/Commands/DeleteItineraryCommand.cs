using MediatR;

namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class DeleteItineraryCommand : IRequest<bool>
    {
        public int ItineraryId { get; set; }

        public DeleteItineraryCommand(int itineraryId)
        {
            ItineraryId = itineraryId;
        }
    }
}
