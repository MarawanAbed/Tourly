

using MediatR;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Delete
{
    public class DeleteBookingCommand : IRequest
    {
        public int BookingId { get; set; }
    }
}
