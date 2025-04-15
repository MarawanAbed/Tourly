

using MediatR;

namespace TravelBookingPortal.Application.Admin.Hotels.Commands.Delete
{
    public class DeleteHotelCommand : IRequest
    {
        public int HotelId { get; set; }
    }

}
