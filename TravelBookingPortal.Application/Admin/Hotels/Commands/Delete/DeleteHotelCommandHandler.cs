
using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Hotels;

namespace TravelBookingPortal.Application.Admin.Hotels.Commands.Delete
{
    public class DeleteHotelCommandHandler(IHotels hotels) : IRequestHandler<DeleteHotelCommand>
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
