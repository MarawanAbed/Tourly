

using MediatR;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Admin.Booking.Commands.Create
{
    public class CreateBookingCommand : IRequest
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string BookingStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
