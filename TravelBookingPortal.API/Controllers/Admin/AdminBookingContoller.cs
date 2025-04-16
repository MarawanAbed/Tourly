using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Booking.Commands.Create;
using TravelBookingPortal.Application.Admin.Booking.Commands.Delete;
using TravelBookingPortal.Application.Admin.Booking.Queries;

namespace TravelBookingPortal.API.Controllers.Admin
{
    [Route("Admin/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminBookingContoller(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {

            var result = await mediator.Send(new GetAllBookingsQuery());
            return Ok(result);
        }
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
        {
            await mediator.Send(command);
            return Ok(new { Message="Booking Created Successfully"});
        }

        [HttpDelete("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await mediator.Send(new DeleteBookingCommand { BookingId = bookingId });
            return Ok(new {Message= "Booking deleted successfully" });

        }
    }
}
