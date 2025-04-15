

using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Admin.Hotels.Dtos;
using TravelBookingPortal.Domain.Repositories.Admin.Hotels;

namespace TravelBookingPortal.Application.Admin.Hotels.Queries
{
    public class GetAllHotelsQueriesHandler(IMapper mapper,IHotels hotels) : IRequestHandler<GetAllHotelsQueries, List<GetAllHotelsDto>>
    {
        public async Task<List<GetAllHotelsDto>> Handle(GetAllHotelsQueries request, CancellationToken cancellationToken)
        {
            var hotelsList = await hotels.GetAllHotels();
            return mapper.Map<List<GetAllHotelsDto>>(hotelsList);
        }
    }

}
