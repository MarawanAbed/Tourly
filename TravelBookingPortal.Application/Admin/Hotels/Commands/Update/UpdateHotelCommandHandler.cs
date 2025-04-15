
using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Repositories.Admin.Hotels;


namespace TravelBookingPortal.Application.Admin.Hotels.Commands.Update
{
    public class UpdateHotelCommandHandler(IHotels hotels,IMapper mapper) : IRequestHandler<UpdateHotelCommand>
    {
        public async Task Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {

            var hotel= mapper.Map<Hotel>(request);

            await hotels.UpdateHotel(hotel);

        }
    }
}
