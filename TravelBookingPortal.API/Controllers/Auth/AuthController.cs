using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Auth.Login.Commands;
using TravelBookingPortal.Application.Auth.logout.Commands;
using TravelBookingPortal.Application.Auth.Register.Commands;

namespace TravelBookingPortal.API.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterCommand command)
        {
            try 
            {
                var result = await mediator.Send(command);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutCommand command)
        {
             await mediator.Send(command);
            return Ok(new { message = "Logout successful" });
        }

    }
}
