
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Review;
using TravelBookingPortal.Application.Reviews.Dtos;

namespace TravelBookingPortal.Application.Reviews.Queries.GetReviewsByHotel
{
    public class GetReviewsByHotelQueryHandler(IReviewRepository repository, IMapper mapper) : IRequestHandler<GetReviewsByHotelQuery, List<ReviewDto>>
    {
        public async Task<List<ReviewDto>> Handle(GetReviewsByHotelQuery request, CancellationToken cancellationToken)
        {
            var reviews = await repository.GetByHotelByNameAsync(request.HotelName);
            return mapper.Map<List<ReviewDto>>(reviews);
        }
    }
}