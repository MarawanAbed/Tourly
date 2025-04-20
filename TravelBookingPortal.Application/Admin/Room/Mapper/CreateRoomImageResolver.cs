
using AutoMapper;
using TravelBookingPortal.Application.Admin.Room.Commands.Create;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Entites.Room;

namespace TravelBookingPortal.Application.Admin.Room.Mapper
{
    public class CreateRoomImageResolver : IValueResolver<CreateRoomCommand, RoomEntities, string>
    {
        public  string Resolve(CreateRoomCommand source, RoomEntities destination, string destMember, ResolutionContext context)
        {
            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
