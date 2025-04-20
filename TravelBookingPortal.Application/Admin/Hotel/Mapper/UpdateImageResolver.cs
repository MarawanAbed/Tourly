

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotel.Commands.Update;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Entites.Hotel;

namespace TravelBookingPortal.Application.Admin.Hotel.Mapper
{
    public class UpdateImageUrlResolver : IValueResolver<UpdateHotelCommand, HotelEntities, string>
    {
        public string Resolve(UpdateHotelCommand source, HotelEntities destination, string destMember, ResolutionContext context)
        {

            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
