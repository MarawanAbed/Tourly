
using MediatR;

namespace TravelBookingPortal.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}