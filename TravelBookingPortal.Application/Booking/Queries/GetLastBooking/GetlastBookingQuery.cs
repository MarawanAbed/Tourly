
using MediatR;
using TravelBookingPortal.Application.Booking.Dtos;

namespace TravelBookingPortal.Application.Booking.Queries.GetLastBooking
{
    public class GetlastBookingQuery : IRequest<GetLastBookingByUserIdDTO>
    {
        public string UserId { get; set; }
        public GetlastBookingQuery(string userId)
        {
            UserId = userId;
        }
    }
}
