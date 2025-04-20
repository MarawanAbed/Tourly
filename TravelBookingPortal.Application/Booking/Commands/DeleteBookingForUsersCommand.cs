
using MediatR;

namespace TravelBookingPortal.Application.Booking.Commands
{
    public class DeleteBookingForUsersCommand : IRequest
    {
        public int BookingId { get; set; }
    }
}
