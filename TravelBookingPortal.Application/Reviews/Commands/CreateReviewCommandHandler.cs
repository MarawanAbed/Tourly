using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Enitites.ReviewEntities;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;

namespace TravelBookingPortal.Application.Reviews.Commands
{
 
        public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
        {
            private readonly IReviewRepository _repository;
            private readonly IMapper _mapper;

            public CreateReviewCommandHandler(IReviewRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
            {
                var review = _mapper.Map<Review>(request.ReviewDto);
                review.CreatedAt = DateTime.UtcNow;
                await _repository.AddAsync(review);
                return Unit.Value;
            }

        Task IRequestHandler<CreateReviewCommand>.Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
    }
