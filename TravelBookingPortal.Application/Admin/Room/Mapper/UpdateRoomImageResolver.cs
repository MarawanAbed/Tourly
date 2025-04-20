

using AutoMapper;
using TravelBookingPortal.Application.Admin.Room.Commands.Update;
using TravelBookingPortal.Application.Helper;

using TravelBookingPortal.Domain.Entites.Room;

namespace TravelBookingPortal.Application.Admin.Room.Mapper
{
    public class UpdateRoomImageResolver : IValueResolver<UpdateRoomsCommand, RoomEntities, string>
    {
        public string Resolve(UpdateRoomsCommand source, RoomEntities destination, string destMember, ResolutionContext context)
        {
            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
