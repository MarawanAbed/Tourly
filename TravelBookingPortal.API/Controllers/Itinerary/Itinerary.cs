using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBookingPortal.Application.Itinerary.Commands.CreateItinerary;
using TravelBookingPortal.Application.Itinerary.Commands.DeleteItinerary;
using TravelBookingPortal.Application.Itinerary.Commands.UpdateItinerary;
using TravelBookingPortal.Application.Itinerary.Queries.GetAllItineraries;
using TravelBookingPortal.Application.Itinerary.Queries.GetItinerariesByUserId;
using TravelBookingPortal.Application.Itinerary.Queries.GetItineraryById;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;

namespace TravelBookingPortal.API.Controllers.Itinerary
{
    [Route("[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItineraryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get all itineraries
        [HttpGet("get-all")]
        public async Task<ActionResult<List<ItineraryDto>>> GetAll()
        {
            return await _mediator.Send(new GetAllItinerariesQuery());
        }

        // Get itinerary by itineraryId
        [HttpGet("get/{itineraryId}")]
        public async Task<ActionResult<ItineraryDto>> GetByItineraryId(int itineraryId)
        {
            var itinerary = await _mediator.Send(new GetItineraryByIdQuery { ItineraryId = itineraryId });  // Pass ItineraryId
            if (itinerary == null)
                return NotFound();

            return itinerary;
        }


        // Create a new itinerary
        [HttpPost("add")]
        public async Task<ActionResult<int>> Create([FromBody] CreateItineraryCommand command)
        {
            var itineraryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByItineraryId), new { itineraryId }, itineraryId);
        }


        // Update an existing itinerary
        [HttpPut("edit")]
        public async Task<ActionResult> Update([FromBody] UpdateItineraryCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        }


        // Delete an itinerary
        [HttpDelete("delete/{userId}/{itineraryId}")]
        public async Task<ActionResult> Delete(string userId, int itineraryId)
        {
            var success = await _mediator.Send(new DeleteItineraryCommand(userId, itineraryId));
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserItineraries()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();

            var query = new GetItinerariesByUserIdQuery(userId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}