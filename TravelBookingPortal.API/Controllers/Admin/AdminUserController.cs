using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Users.Commnads.ChangeRole;
using TravelBookingPortal.Application.Admin.Users.Queries;

namespace TravelBookingPortal.API.Controllers.Admin
{
    [Route("Admin/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminUserController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpPost("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUsersRoleCommnad command)
        {
            await mediator.Send(command);
            return Ok("User role changed successfully");
        }
    }
}
