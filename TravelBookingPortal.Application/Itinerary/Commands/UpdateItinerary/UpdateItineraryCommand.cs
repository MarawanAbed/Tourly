using MediatR;

namespace TravelBookingPortal.Application.Itinerary.Commands.UpdateItinerary
{
    public class UpdateItineraryCommand : IRequest<bool>
    {
        public int ItineraryId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
