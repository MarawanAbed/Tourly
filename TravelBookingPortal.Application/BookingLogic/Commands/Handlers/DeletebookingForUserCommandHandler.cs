using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TravelBookingPortal.Application.BookingLogic.Commands.Models;
using TravelBookingPortal.Domain.Enitites.RoomEntities;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.BookingRepo;

namespace TravelBookingPortal.Application.BookingLogic.Commands.Handlers
{
    class DeletebookingForUserCommandHandler :IRequestHandler<DeleteBookingForUsersCommand>
    {
        private readonly IBookingRepository bookingRepository;
        private readonly IBookingStatusNotifier notifier;

        public DeletebookingForUserCommandHandler(IBookingRepository bookingRepository, IBookingStatusNotifier notifier)
        {
            
            this.bookingRepository = bookingRepository;
            this.notifier = notifier;
        }

        public IBookingStatusNotifier Notifier { get; }

        async Task IRequestHandler<DeleteBookingForUsersCommand>.Handle(DeleteBookingForUsersCommand request, CancellationToken cancellationToken)
        {
            var booking = await bookingRepository.GetBookingByIdAsync(request.BookingId);
            int roomId = booking.RoomId;
            await bookingRepository.DeleteBookingForUserAsync(request.BookingId);
            await notifier.NotifyBookingStatusAsync(roomId, "Available");

        }
    }
    
}
