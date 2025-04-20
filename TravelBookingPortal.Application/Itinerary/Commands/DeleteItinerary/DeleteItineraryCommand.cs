using MediatR;

namespace TravelBookingPortal.Application.Itinerary.Commands.DeleteItinerary
{
    public class DeleteItineraryCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public int ItineraryId { get; set; }

        public DeleteItineraryCommand(string userId, int itineraryId)
        {
            UserId = userId;
            ItineraryId = itineraryId;
        }
    }
}
