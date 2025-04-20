using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.User.Commnads.ChangeRole;
using TravelBookingPortal.Application.Admin.User.Commnads.DeleteUser;
using TravelBookingPortal.Application.Admin.User.Queries.GetAllAdmins;
using TravelBookingPortal.Application.Admin.User.Queries.GetAllUsers;

namespace TravelBookingPortal.API.Controllers.Admin.User
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

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var result = await mediator.Send(new GetAllAdminsQuery());
            return Ok(result);
        }
        [HttpPost("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeUsersRoleCommnad command)
        {
            await mediator.Send(command);
            return Ok(new { message = "User role changed successfully" });
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await mediator.Send(new DeleteUserCommand { UserId = userId });
            return Ok(new { message = "User deleted successfully" });
        }

    }
}
