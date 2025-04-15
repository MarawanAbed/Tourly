using MediatR;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Domain.Enitites.BookingEntities;
using TravelBookingPortal.Domain.IHubs;
using TravelBookingPortal.Domain.Repositories;
using TravelBookingPortal.Domain.Repositories.BookingRepo;

public class ConfirmBookingAfterPaymentHandler : IRequestHandler<ConfirmBookingAfterPaymentCommand,Unit>
{
    private readonly IBookingRepository _bookingRepository;
    

    public ConfirmBookingAfterPaymentHandler(
        IBookingRepository bookingRepository
        )
    {
        _bookingRepository = bookingRepository;
        
    }

    public async Task<Unit> Handle(ConfirmBookingAfterPaymentCommand request, CancellationToken cancellationToken)
    {
       
        var booking = await _bookingRepository.GetBookingByIdAsync(request.BookingId);

        

       
        await _bookingRepository.UpdateAsync(booking);

        

        return Unit.Value;
    }

   
}
