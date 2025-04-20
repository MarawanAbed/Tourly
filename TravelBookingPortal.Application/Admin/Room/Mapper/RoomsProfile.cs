

using AutoMapper;
using TravelBookingPortal.Application.Admin.Room.Commands.Create;
using TravelBookingPortal.Application.Admin.Room.Commands.Update;
using TravelBookingPortal.Application.Admin.Room.Dtos;
using TravelBookingPortal.Domain.Entites.Room;

namespace TravelBookingPortal.Application.Admin.Room.Mapper
{
    public class RoomsProfile : Profile
    {
        public RoomsProfile()
        {
            CreateMap<RoomEntities, CreateRoomCommand>();


            CreateMap<CreateRoomCommand, RoomEntities>()
                .ForMember(des => des.ImageUrl,
                opt => opt.MapFrom<CreateRoomImageResolver>());

            CreateMap<UpdateRoomsCommand, RoomEntities>()
                .ForMember(des => des.ImageUrl,
                opt => opt.MapFrom<UpdateRoomImageResolver>());

            CreateMap<RoomEntities, GetAllRoomsDto>()
                .ForMember(des => des.HotelName
                , opt => opt.MapFrom(src => src.Hotel.Name));
        }
    }
}
