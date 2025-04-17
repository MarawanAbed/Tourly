using MediatR;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Repositories.Admin.Cities;

namespace TravelBookingPortal.Application.Admin.cities.Commands.Update
{
    public class UpdateCityCommandHandler(ICities cities) : IRequestHandler<UpdateCityCommand>
    {
        public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            string ImageUrl =await ImageUpload.UploadImage(request.ImageUrl);
            var city = new Domain.Enitites.CityEnities.City
            {
                CityId = request.CityId,
                Name = request.Name,
                ImageUrl = ImageUrl
            };
            await cities.UpdateCity(city);
        }
    }
}
