using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Create;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Delete;
using TravelBookingPortal.Application.Admin.Rooms.Commands.Update;
using TravelBookingPortal.Application.Admin.Rooms.Queries;

namespace TravelBookingPortal.API.Controllers.Admin
{
    [Route("Admin/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminRoomController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await mediator.Send(new GetAllRoomsQuery ());
            return Ok(result);
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromForm] CreateRoomCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(nameof(GetAllRooms), new { hotelId = command.HotelId });
        }

        [HttpDelete("DeleteRoom")]

        public async Task<IActionResult> DeleteRoom( int roomId)
        {
            await mediator.Send(new DeleteRoomsCommand { RoomId=roomId});
            return NoContent();
        }

        [HttpPut("UpdateRoom")]

        public async Task<IActionResult> UpdateRoom([FromForm] UpdateRoomsCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

    }
}
