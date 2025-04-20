

using MediatR;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Application.Interfaces.Repositories.Admin.City;
using TravelBookingPortal.Domain.Entites.City;

namespace TravelBookingPortal.Application.Admin.city.Commands.Create
{
    internal class CreateCityCommandHandler(ICityRepository cities) : IRequestHandler<CreateCityCommand>
    {
        public async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var ImageUrl = await ImageUpload.UploadImage(request.ImageUrl);
            var city = new CityEntities
            {
                Name = request.Name,
                ImageUrl = ImageUrl
            };
            await cities.AddCity(city);
        }
    }
}
