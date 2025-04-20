using MediatR;
using TravelBookingPortal.Application.Helper;

using TravelBookingPortal.Application.Interfaces.Repositories.Admin.City;
using TravelBookingPortal.Domain.Entites.City;

namespace TravelBookingPortal.Application.Admin.city.Commands.Update
{
    public class UpdateCityCommandHandler(ICityRepository cities) : IRequestHandler<UpdateCityCommand>
    {
        public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            string ImageUrl = await ImageUpload.UploadImage(request.ImageUrl);
            var city = new CityEntities
            {
                CityId = request.CityId,
                Name = request.Name,
                ImageUrl = ImageUrl
            };
            await cities.UpdateCity(city);
        }
    }
}
