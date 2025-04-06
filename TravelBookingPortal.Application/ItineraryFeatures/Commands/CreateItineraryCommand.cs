using MediatR;
namespace TravelBookingPortal.Application.ItineraryFeatures.Commands
{
    public class CreateItineraryCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
