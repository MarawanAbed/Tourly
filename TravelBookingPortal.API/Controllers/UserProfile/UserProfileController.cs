using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.UserProfile.Commands;
using TravelBookingPortal.Application.UserProfile.Queries;

namespace TravelBookingPortal.API.Controllers.UserProfile
{
    public class UserProfileController : Controller
    {
        private readonly IMediator _mediator;
        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserProfile(string userId)
        {
            var query = new GetUserProfileQuery(userId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("user")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileCommand command)
        {


            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
