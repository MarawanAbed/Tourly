using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Infrastructure.Hubs;

namespace TravelBookingPortal.API.Controllers.PaymentController
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentWebhookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentWebhookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("callback")]
        public async Task<IActionResult> Callback([FromBody] dynamic payload)
        {
            int bookingId = payload.booking_id;
            bool isSuccess = payload.success;

            if (isSuccess)
            {
                await _mediator.Send(new ConfirmBookingCommand { BookingId = bookingId });
            }

            return Ok();
        }
    }
}
