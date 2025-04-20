
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;
using TravelBookingPortal.Domain.Entites.Review;


namespace TravelBookingPortal.Application.Reviews.Commands.CreateReview
{

    public class CreateReviewCommandHandler(IReviewRepository repository, IMapper mapper) : IRequestHandler<CreateReviewCommand>
    {
        public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<ReviewEntities>(request);
            review.CreatedAt = DateTime.UtcNow;
            await repository.AddAsync(review, request.HotelName);
            return Unit.Value;
        }

        Task IRequestHandler<CreateReviewCommand>.Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
