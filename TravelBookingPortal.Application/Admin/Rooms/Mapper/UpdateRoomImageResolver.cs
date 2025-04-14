

using AutoMapper;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Create;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Update;
using TravelBookingPortal.Application.Helper;
using TravelBookingPortal.Domain.Enitites.HotelEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;

namespace TravelBookingPortal.Application.Admin.Rooms.Mapper
{
    public class UpdateRoomImageResolver : IValueResolver<UpdateRoomsCommand, Room, string>
    {
        public string Resolve(UpdateRoomsCommand source, Room destination, string destMember, ResolutionContext context)
        {
            if (source.ImageUrl != null)
            {
                return ImageUpload.UploadImage(source.ImageUrl).Result;
            }
            return null;
        }
    }
}
