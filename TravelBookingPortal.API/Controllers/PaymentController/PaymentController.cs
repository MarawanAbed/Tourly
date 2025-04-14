using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Application.Payment.DTOS;
using TravelBookingPortal.Application.Payment.PaymentService;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Microsoft.Extensions.Logging;
using System.Text.Json;
namespace TravelBookingPortal.API.Controllers.PaymentController
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator, ILogger<PaymentController> _logger)
        {
            _mediator = mediator;
            this._logger = _logger;

        }


        [HttpPost("callback")]
        public async Task<IActionResult> PaymentCallback([FromBody] JsonElement payload)
        {
            _logger.LogInformation("Received callback payload");

            if (payload.TryGetProperty("obj", out JsonElement objElement) &&
                objElement.TryGetProperty("order", out JsonElement orderElement) &&
                orderElement.TryGetProperty("merchant_order_id", out JsonElement merchantOrderIdElement))
            {
                string merchantOrderId = merchantOrderIdElement.GetString();
                _logger.LogInformation($"Merchant Order ID: {merchantOrderId}");
                await _mediator.Send(new ConfirmBookingAfterPaymentCommand(int.Parse(merchantOrderId)));
            }
            else
            {
                _logger.LogWarning("Merchant Order ID not found in payload");
            }

            return Ok();
        }

    }
}