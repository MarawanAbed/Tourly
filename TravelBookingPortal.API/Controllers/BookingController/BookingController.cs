using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.Booking.Commands.Delete;
using TravelBookingPortal.Application.BookingLogic.Commands.Models;
using TravelBookingPortal.Application.BookingLogic.Queries.Models;

namespace TravelBookingPortal.API.Controllers.BookingController
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookingController> _logger;
        public BookingController(IMediator mediator, ILogger<BookingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBookingsByUserId(string userId)
        {
            try
            {
                var bookings = await _mediator.Send(new GetBookingsByUserIdQuery { UserId = userId });
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving bookings for user {UserId}", userId);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("DeleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            try
            {
                await _mediator.Send(new DeleteBookingForUsersCommand { BookingId = bookingId });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting booking with ID {BookingId}", bookingId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

