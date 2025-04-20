

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotel.Commands.Create;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Entites.Hotel;

namespace TravelBookingPortal.Application.Admin.Hotel.Mapper
{
    public class CreateImageUrlResolver : IValueResolver<CreateHotelCommand, HotelEntities, string>
    {
        public string Resolve(CreateHotelCommand source, HotelEntities destination, string destMember, ResolutionContext context)
        {

            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
