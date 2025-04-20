
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel;


namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Delete
{
    public class DeleteHotelCommandHandler(IHotelsRepository hotels) : IRequestHandler<DeleteHotelCommand>
    {
        public async Task Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            var hotelId = request.HotelId;
            if (hotelId == 0)
            {
                throw new ArgumentException("Hotel ID cannot be zero.");
            }
            await hotels.DeleteHotel(request.HotelId);
        }
    }
}
