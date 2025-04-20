

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Hotel.Dtos;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.Hotel;


namespace TravelBookingPortal.Application.Admin.Hotel.Queries
{
    public class GetAllHotelsQueriesHandler(IMapper mapper,IHotelsRepository hotels) : IRequestHandler<GetAllHotelsQueries, List<GetAllHotelsDto>>
    {
        public async Task<List<GetAllHotelsDto>> Handle(GetAllHotelsQueries request, CancellationToken cancellationToken)
        {
            var hotelsList = await hotels.GetAllHotels();
            return mapper.Map<List<GetAllHotelsDto>>(hotelsList);
        }
    }

}
