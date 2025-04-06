using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Payment.DTOS;
using TravelBookingPortal.Application.Payment.PaymentService;


namespace TravelBookingPortal.API.Controllers.PaymentController
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("initiate")]
        public async Task<IActionResult> InitiatePayment([FromBody] PaymentRequestDto dto)
        {
            var url = await _paymentService.GeneratePaymentUrl(dto.Amount, dto.BookingId);
            return Ok(new PaymentResponseDto { PaymentUrl = url });
        }
    }
}
