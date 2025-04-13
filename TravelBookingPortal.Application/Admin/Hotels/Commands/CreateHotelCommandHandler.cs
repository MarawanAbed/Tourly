

using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Repositories.Admin.Hotels;

namespace TravelBookingPortal.Application.Admin.Hotels.Commands
{
    public class CreateHotelCommandHandler(IMapper mapper, IHotels hotels) : IRequestHandler<CreateHotelCommand>
    {
        public async Task Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = mapper.Map<Hotel>(request);
            await hotels.AddHotel(hotel);
        }
    }
}
