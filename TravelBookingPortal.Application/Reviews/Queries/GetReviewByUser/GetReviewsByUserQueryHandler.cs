
using MediatR;
using TravelBookingPortal.Application.Reviews.Dtos;
using AutoMapper;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;

namespace TravelBookingPortal.Application.Reviews.Queries.GetReviewByUser
{
    public class GetReviewsByUserQueryHandler(IReviewRepository repository, IMapper mapper) : IRequestHandler<GetReviewsByUserQuery, List<ReviewDto>>
    {
        public async Task<List<ReviewDto>> Handle(GetReviewsByUserQuery request, CancellationToken cancellationToken)
        {
            var reviews = await repository.GetByUserIdAsync(request.UserId);
            return mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}
