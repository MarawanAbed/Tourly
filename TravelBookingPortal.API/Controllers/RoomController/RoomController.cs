using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.RoomLogic.Commands.Models;
using TravelBookingPortal.Application.RoomLogic.Queries.Models;
using TravelBookingPortal.Application.BookingLogic.Queries.Models;
using TravelBookingPortal.Application.Payment.PaymentService;

namespace TravelBookingPortal.API.Controllers.RoomController
{
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPaymentService paymentService;

        public RoomController(IMediator mediator, IPaymentService paymentService)
        {
            _mediator = mediator;
            this.paymentService = paymentService;
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
            return RedirectToAction("GetLastPendingBooking", new { userId = book.UserId });
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
        [HttpGet("GetLastBooking/{userId}")]

        public async Task <IActionResult> GetLastPendingBooking(string userId)
        {
            var booking = await _mediator.Send(new GetlastBookingQuery(userId));
            if (booking == null)
            {
                return NotFound();
            }

            var url = await paymentService.GeneratePaymentUrl(booking.TotalPrice, booking.BookingId);
            return Ok(url);
        }


    }
}
