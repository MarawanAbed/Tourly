using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;

namespace TravelBookingPortal.Application.Reviews.Commands
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IReviewRepository _repository;

        public DeleteReviewCommandHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ReviewId);
            return Unit.Value;
        }

        Task IRequestHandler<DeleteReviewCommand>.Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}