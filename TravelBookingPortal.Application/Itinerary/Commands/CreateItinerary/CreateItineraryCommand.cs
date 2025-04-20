using MediatR;
namespace TravelBookingPortal.Application.Itinerary.Commands.CreateItinerary
{
    public class CreateItineraryCommand : IRequest<int>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
