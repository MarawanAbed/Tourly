
using MediatR;

namespace TravelBookingPortal.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
    }
}