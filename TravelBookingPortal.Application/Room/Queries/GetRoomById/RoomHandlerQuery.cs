
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Room;
using TravelBookingPortal.Application.Room.Dtos;
using TravelBookingPortal.Application.Room.Queries.GetAvailableRooms;

namespace TravelBookingPortal.Application.Room.Queries.GetRoomById
{
    class RoomHandlerQuery(IRoomRepository roomRepository, IMapper mapper) : IRequestHandler<GetAvailableRoomsListQuery, IEnumerable<GetRoomsDTO>>
    {
        public async Task<IEnumerable<GetRoomsDTO>> Handle(GetAvailableRoomsListQuery request, CancellationToken cancellationToken)
        {
            var roomList = await roomRepository.GetRoomByCityAndAvailabilityAsync(
                request.City, request.CheckIn, request.CheckOut, request.RoomType);

            var roomDtos = new List<GetRoomsDTO>();

            foreach (var room in roomList)
            {

                bool hasPendingConflict = room.Bookings.Any(b =>
                    b.BookingStatus == "Pending" &&
                    request.CheckIn < b.CheckOutDate && request.CheckOut > b.CheckInDate
                );

                var dto = mapper.Map<GetRoomsDTO>(room);
                dto.BookingStatus = hasPendingConflict ? "Not Available" : "Available";
                dto.IsBookable = !hasPendingConflict;

                roomDtos.Add(dto);
            }

            return roomDtos;
        }
    }
}
