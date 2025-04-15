using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TravelBookingPortal.Application.Reviews.DTOs;
using AutoMapper;
using TravelBookingPortal.Domain.Repositories.ReviewRepo;

namespace TravelBookingPortal.Application.Reviews.Queries
{
    public class GetReviewsByUserHandler : IRequestHandler<GetReviewsByUserQuery, List<ReviewDto>>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public GetReviewsByUserHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewsByUserQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetByUserIdAsync(request.UserId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}
