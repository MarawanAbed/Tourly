using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.ContactUs.Commands.SendContactForm;

namespace TravelBookingPortal.API.Controllers.ContactUs
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendContact([FromBody] SendContactFormCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok(new { message = "Message sent successfully!" });
            else
                return StatusCode(500, "Error sending message.");
        }
    }
}
