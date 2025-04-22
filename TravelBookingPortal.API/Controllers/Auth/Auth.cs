using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBookingPortal.Application.Auth.Login.Commands;
using TravelBookingPortal.Application.Auth.logout.Commands;
using TravelBookingPortal.Application.Auth.Register.Commands;
using TravelBookingPortal.Application.Services.ExternalAuth;


namespace TravelBookingPortal.API.Controllers.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator,IExternalAuthService externalAuthServices) : ControllerBase
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

        [HttpDelete("logout/{userId}")]
        public async Task<IActionResult> Logout(string userId)
        {
            await mediator.Send(new LogoutCommand { UserId=userId});
            return Ok(new { message = "Logout successful" });
        }

        [HttpGet("externallogin")]
        public IActionResult ExternalLogin([FromQuery] string provider, [FromQuery] string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "auth", new { returnUrl });
            var properties = externalAuthServices.ConfigureExternalLogin(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet("externallogin-callback")]
        public async Task<IActionResult> ExternalLoginCallback()
        {
                var result = await externalAuthServices.HandleExternalLoginCallback();

                if (result == null || string.IsNullOrEmpty(result.Token))
                {
                    return Redirect("http://localhost:4200/Login?error=OAuthFailed");
                }

                var redirectUrl = $"http://localhost:4200/Login?token={result.Token}&userId={result.UserId}";
                return Redirect(redirectUrl);
        }

    }
}
