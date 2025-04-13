using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Booking.Commands.Create;
using TravelBookingPortal.Application.Admin.Booking.Queries;
using TravelBookingPortal.Application.Admin.cities.Commands;
using TravelBookingPortal.Application.Admin.cities.Queries;
using TravelBookingPortal.Application.Admin.Rooms.Commands;
using TravelBookingPortal.Application.Admin.Users.Commnads;

namespace TravelBookingPortal.API.Controllers.Admin
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings([FromQuery] int hotelId)
        {
            var query = new GetAllBookingsQuery { HotelId = hotelId };

            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
        {
            await mediator.Send(command);
            return Ok("Booking created successfully");
        }

        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await mediator.Send(new GetAllCitiesQuery());
            return Ok(result);
        }
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand command)
        {
            await mediator.Send(command);
            return Ok("City Created Successfully");
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms([FromQuery] int hotelId)
        {
            var result = await mediator.Send(new TravelBookingPortal.Application.Admin.Rooms.Queries.GetAllRoomsQuery { HotelId = hotelId });
            return Ok(result);
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            await mediator.Send(command);
            return CreatedAtAction(nameof(GetAllRooms), new { hotelId = command.HotelId });
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await mediator.Send(new TravelBookingPortal.Application.Admin.Users.Queries.GetAllUsersQuery());
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
