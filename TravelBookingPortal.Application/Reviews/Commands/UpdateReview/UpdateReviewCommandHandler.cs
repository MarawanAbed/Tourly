
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;

namespace TravelBookingPortal.Application.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler(IReviewRepository repository) : IRequestHandler<UpdateReviewCommand>
    {
        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await repository.GetByIdAsync(request.ReviewId);
            if (review == null)
                throw new Exception("Review not found");

            review.Rating = request.Rating;
            review.Comment = request.Comment;

            await repository.UpdateAsync(review);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateReviewCommand>.Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}