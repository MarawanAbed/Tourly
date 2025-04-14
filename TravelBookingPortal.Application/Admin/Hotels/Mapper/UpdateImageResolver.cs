

using AutoMapper;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Create;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Update;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Enitites.HotelEntities;

namespace TravelBookingPortal.Application.Admin.Hotels.Mapper
{
    public class UpdateImageUrlResolver : IValueResolver<UpdateHotelCommand, Hotel, string>
    {
        public string Resolve(UpdateHotelCommand source, Hotel destination, string destMember, ResolutionContext context)
        {

            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
