

using MediatR;

namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Delete
{
    public class DeleteHotelCommand : IRequest
    {
        public int HotelId { get; set; }
    }

}
