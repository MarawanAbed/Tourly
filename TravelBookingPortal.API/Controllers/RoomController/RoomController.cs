using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.RoomLogic.Commands.Models;
using TravelBookingPortal.Application.RoomLogic.Dtos;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TravelBookingPortal.API.Controllers.RoomController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
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
    }
}
