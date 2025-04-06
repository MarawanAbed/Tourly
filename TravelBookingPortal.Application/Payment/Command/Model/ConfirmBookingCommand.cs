
using MediatR;

namespace TravelBookingPortal.Application.Payment.Command.Model
{
    public class ConfirmBookingCommand : IRequest
    {
        public int BookingId { get; set; }
    }
}
