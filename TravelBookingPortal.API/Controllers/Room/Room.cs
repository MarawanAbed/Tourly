using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Booking.Queries.GetLastBooking;
using TravelBookingPortal.Application.Room.Commands;
using TravelBookingPortal.Application.Room.Queries.GetAvailableRooms;
using TravelBookingPortal.Application.Services.Payment;

namespace TravelBookingPortal.API.Controllers.Room
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController(IMediator mediator, IPaymentService paymentService) : ControllerBase
    {
        [HttpGet("GetAvailableRooms")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery]GetAvailableRoomsListQuery request)
        {
            var rooms = await mediator.Send(request);
            return Ok(rooms);
        }
        [HttpPost("book")]
        public async Task<IActionResult> BookRoom([FromBody]BookRoomCommand book)
        {
             await mediator.Send(book);
            return RedirectToAction("GetLastPendingBooking", new { userId = book.UserId });
        }
        [HttpGet("GetRoomById/{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await mediator.Send(new GetRoomByIdQuery { Id = id });
            if (room == null)
            {
                return NotFound();
            }
            
            return Ok(room);
        }
        [HttpGet("GetLastBooking/{userId}")]

        public async Task <IActionResult> GetLastPendingBooking(string userId)
        {
            var booking = await mediator.Send(new GetlastBookingQuery(userId));
            if (booking == null)
            {
                return NotFound();
            }

            var url = await paymentService.GeneratePaymentUrl(booking.TotalPrice, booking.BookingId);
            return Ok(url);
        }


    }
}
