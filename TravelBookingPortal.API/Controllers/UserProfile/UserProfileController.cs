using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpPut("user/{userId}")]
        public async Task<IActionResult> UpdateUserProfile(string userId, [FromForm] UpdateUserProfileCommand command)
        {
            command.UserId = userId;


            var result = await _mediator.Send(command);
            if (!result)
            {
                return BadRequest(new {error="Failed To Update Profile"});
            }
            return NoContent();
        }
    }
}
