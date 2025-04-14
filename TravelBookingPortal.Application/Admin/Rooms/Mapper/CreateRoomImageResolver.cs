
using AutoMapper;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Create;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Rooms.Mapper
{
    public class CreateRoomImageResolver : IValueResolver<CreateRoomCommand, Room, string>
    {
        public  string Resolve(CreateRoomCommand source, Room destination, string destMember, ResolutionContext context)
        {
            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
