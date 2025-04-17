using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Payment.Command.Model;
using TravelBookingPortal.Application.Payment.DTOS;
using TravelBookingPortal.Application.Payment.PaymentService;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
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


        

        [HttpGet("response-callback")]
        public IActionResult ResponseCallback(
            [FromQuery] bool? success,
            [FromQuery(Name = "id")] string transactionId, // Map 'id' from query to transactionId
            [FromQuery] int? amount_cents)
        {
            _logger.LogInformation($"Received response callback. Success: {success}, Transaction ID: {transactionId}, Amount: {amount_cents}");

            // Determine the Angular redirect URL
            string angularBaseUrl = "http://localhost:4200"; // Use localhost for local testing
            string redirectUrl;

            if (success == true)
            {
                redirectUrl = $"{angularBaseUrl}/payment-success?transaction_id={transactionId}&amount_cents={amount_cents}";
            }
            else
            {
                redirectUrl = $"{angularBaseUrl}/payment-failure?transaction_id={transactionId}&amount_cents={amount_cents}";
            }

            _logger.LogInformation($"Redirecting to: {redirectUrl}");
            return Redirect(redirectUrl);
        }
    }
}


