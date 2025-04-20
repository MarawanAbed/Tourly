
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;

namespace TravelBookingPortal.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler(IReviewRepository repository) : IRequestHandler<DeleteReviewCommand>
    {
        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.ReviewId);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteReviewCommand>.Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}