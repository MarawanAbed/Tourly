

using AutoMapper;
using TravelBookingPortal.Application.Auth.Register.Commands;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Enitites.User;

namespace TravelBookingPortal.Application.Auth.Register.Mapper
{
    public class ImageUrlResolver : IValueResolver<RegisterCommand, ApplicationUser, string>
    {
        public string Resolve(RegisterCommand source, ApplicationUser destination, string destMember, ResolutionContext context)
        {
            if (source.Image != null)
            {
                return ImageUpload.UploadImage(source.Image).Result;
            }
            return null;
        }
    }
}
