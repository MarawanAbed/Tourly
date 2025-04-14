

using MediatR;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Enitites.CityEnities;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;

namespace TravelBookingPortal.Application.Admin.cities.Commands.Create
{
    internal class CreateCityCommandHandler( ICities cities) : IRequestHandler<CreateCityCommand>
    {
        public async Task Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var ImageUrl = await ImageUpload.UploadImage(request.ImageUrl);
            var city = new City
            {
                Name = request.Name,
                ImageUrl = ImageUrl
            };
            await cities.AddCity(city);
        }
    }
}
