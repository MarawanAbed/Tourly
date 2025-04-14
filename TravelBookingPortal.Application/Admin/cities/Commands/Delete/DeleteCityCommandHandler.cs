

using MediatR;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;

namespace TravelBookingPortal.Application.Admin.cities.Commands.Delete
{
    public class DeleteCityCommandHandler(ICities cities) : IRequestHandler<DeleteCityCommand>
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
