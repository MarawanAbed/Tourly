using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;

namespace TravelBookingPortal.Application.Reviews.Commands
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IReviewRepository _repository;

        public UpdateReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _repository.GetByIdAsync(request.ReviewId);
            if (review == null)
                throw new Exception("Review not found");

            review.Rating = request.Rating;
            review.Comment = request.Comment;

            await _repository.UpdateAsync(review);

            return Unit.Value;
        }

        Task IRequestHandler<UpdateReviewCommand>.Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}