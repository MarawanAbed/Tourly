using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.ItineraryFeatures.Commands;
using TravelBookingPortal.Application.ItineraryFeatures.Dtos;
using TravelBookingPortal.Application.ItineraryFeatures.Queries;

[Route("api/[controller]")]
[ApiController]
public class ItineraryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItineraryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<ActionResult<List<ItineraryDto>>> GetAll()
    {
        return await _mediator.Send(new GetAllItinerariesQuery());
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<ItineraryDto>> GetById(int id)
    {
        var itinerary = await _mediator.Send(new GetItineraryByIdQuery { ItineraryId = id });
        if (itinerary == null)
            return NotFound();

        return itinerary;
    }

    [HttpPost("add")]
    public async Task<ActionResult<int>> Create([FromBody] CreateItineraryCommand command)
    {
        var itineraryId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = itineraryId }, itineraryId);
    }

    [HttpPut("edit/{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateItineraryCommand command)
    {
        if (id != command.ItineraryId)
            return BadRequest();

        var result = await _mediator.Send(command);
        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteItineraryCommand(id));
        if (!success)
            return NotFound();

        return NoContent();
    }
}
