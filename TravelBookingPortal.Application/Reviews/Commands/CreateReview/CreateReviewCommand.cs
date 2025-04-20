
using MediatR;

namespace TravelBookingPortal.Application.Reviews.Commands.CreateReview
{
    public class CreateReviewCommand : IRequest
    {
        public string UserId { get; set; } = null!;
        public string HotelName { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
