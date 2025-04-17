using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.RoomLogic.Commands.Models;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;

namespace TravelBookingPortal.API.Controllers.RoomController
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAvailableRooms")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery]GetAvailableRoomsListQuery request)
        {
            var rooms = await _mediator.Send(request);
            return Ok(rooms);
        }
        [HttpPost("book")]
        public async Task<IActionResult> BookRoom([FromBody]BookRoomCommand book)
        {
             await _mediator.Send(book);
             return Ok();
        }
        [HttpGet("GetRoomById/{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _mediator.Send(new GetRoomByIdQuery { Id = id });
            if (room == null)
            {
                return NotFound();
            }
            
            return Ok(room);
        }

    }
}
