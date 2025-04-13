

using AutoMapper;
using MediatR;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;

namespace TravelBookingPortal.Application.Admin.cities.Commands
{
    internal class CreateCityCommandHandler(IMapper mapper,ICities cities) : IRequestHandler<CreateCityCommand>
    {
        public async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<City>(request);
            await cities.AddCity(city);
        }
    }
}
