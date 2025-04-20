
using MediatR;
using TravelBookingPortal.Application.Reviews.Dtos;

namespace TravelBookingPortal.Application.Reviews.Queries.GetReviewsByHotel
{
    public class GetReviewsByHotelQuery : IRequest<List<ReviewDto>>
    {
        public string HotelName { get; set; }
    }

}
