using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories.BookingRepo;
using TravelBookingPortal.Domain.Repositories.RoomRepo;

namespace TravelBookingPortal.Application.Payment.Command.Handler
{
    public class ConfirmBookingCommandHandler : IRequestHandler<ConfirmBookingCommand>
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly INotificationService _notificationService;

        public ConfirmBookingCommandHandler(IBookingRepository bookingRepo, INotificationService notificationService)
        {
            _bookingRepo = bookingRepo;
            _notificationService = notificationService;
        }

        

         async Task IRequestHandler<ConfirmBookingCommand>.Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(request.BookingId);


            booking.BookingStatus = "Confirmed";
            await _bookingRepo.UpdateAsync(booking);

            await _notificationService.SendBookingConfirmedAsync(request.BookingId);
        }
    }


}
