using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Create;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Delete;
using TravelBookingPortal.Application.Admin.Hotels.Commands.Update;
using TravelBookingPortal.Application.Admin.Hotels.Queries;

namespace TravelBookingPortal.API.Controllers.Admin.Hotel
{
    [Route("Admin/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminHotelController(IMediator mediator) : ControllerBase
    {

        [HttpGet("GetAllHotels")]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await mediator.Send(new GetAllHotelsQueries());
            return Ok(hotels);
        }
        [HttpPost("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromForm] CreateHotelCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("DeleteHotel")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            await mediator.Send(new DeleteHotelCommand { HotelId = hotelId });
            return Ok();
        }

        [HttpPut("UpdateHotel")]
        public async Task<IActionResult> UpdateHotel([FromForm] UpdateHotelCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }
}
