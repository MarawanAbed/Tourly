

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel;
using TravelBookingPortal.Domain.Entites.Hotel;


namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Create
{
    public class CreateHotelCommandHandler(IMapper mapper, IHotelsRepository hotels) : IRequestHandler<CreateHotelCommand>
    {
        public async Task Handle(CreateHotelCommand request, CancellationToken cancellationToken)
        {
            var hotel = mapper.Map<HotelEntities>(request);
            await hotels.AddHotel(hotel);
        }
    }
}
