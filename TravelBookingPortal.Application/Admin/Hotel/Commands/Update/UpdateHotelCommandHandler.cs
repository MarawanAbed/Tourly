
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel;
using TravelBookingPortal.Domain.Entites.Hotel;



namespace TravelBookingPortal.Application.Admin.Hotel.Commands.Update
{
    public class UpdateHotelCommandHandler(IHotelsRepository hotels, IMapper mapper) : IRequestHandler<UpdateHotelCommand>
    {
        public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {

            var hotel = mapper.Map<HotelEntities>(request);

            await hotels.UpdateHotel(hotel);

        }
    }
}
