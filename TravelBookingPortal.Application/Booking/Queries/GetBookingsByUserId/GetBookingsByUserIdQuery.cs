
using MediatR;
using TravelBookingPortal.Application.Booking.Dtos;

namespace TravelBookingPortal.Application.Booking.Queries.GetBookingsByUserId
{
    public class GetBookingsByUserIdQuery : IRequest<List<GetBookingsByUserIdDto>>
    {
        public string UserId { get; set; }
    }
}
