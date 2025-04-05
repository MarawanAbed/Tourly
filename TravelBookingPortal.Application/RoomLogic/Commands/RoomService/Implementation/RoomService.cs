using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

using TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Abstraction;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.RoomLogic.Commands.RoomService.Implementation
{
    public class RoomServiceCommands : IRoomServiceCommands
    {
        private readonly IRoomRepository roomRepository;

        public RoomServiceCommands(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task BookRoomAsync(string userId, int roomId, DateTime checkIn, DateTime checkOut,decimal totalPrice)
        {
            await roomRepository.AddBookingAsync(new Booking
            {
                UserId = userId,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                BookingStatus = "Pending",
                CreatedAt = DateTime.UtcNow,
                TotalPrice = totalPrice


            });

        }
    }
}
