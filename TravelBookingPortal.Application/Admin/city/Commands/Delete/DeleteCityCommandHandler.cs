

using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.City;

namespace TravelBookingPortal.Application.Admin.city.Commands.Delete
{
    public class DeleteCityCommandHandler(ICityRepository cities) : IRequestHandler<DeleteCityCommand>
    {
        public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var cityId = request.CityId;
            if (cityId == 0)
            {
                throw new ArgumentException("City ID cannot be zero.");
            }
            await cities.DeleteCity(request.CityId);
        }
    }
}
