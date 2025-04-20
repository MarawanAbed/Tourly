
using MediatR;
using TravelBookingPortal.Application.Interfaces.Repositories.Booking;
using TravelBookingPortal.Application.Interfaces.Hubs;

namespace TravelBookingPortal.Application.Booking.Commands
{
    class DeletebookingForUserCommandHandler(IBookingRepository bookingRepository, IBookingStatusNotifier notifier) : IRequestHandler<DeleteBookingForUsersCommand>
    {
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
