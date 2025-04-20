
using MediatR;
using TravelBookingPortal.Application.Reviews.Dtos;


namespace TravelBookingPortal.Application.Reviews.Queries.GetReviewByUser
{

    public class GetReviewsByUserQuery : IRequest<List<ReviewDto>>
    {
        public string UserId { get; set; } = null!;
    }
}

