using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.City.Queries;

namespace TravelBookingPortal.API.Controllers.City
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("AllCities")]
        public async Task<IActionResult> GetAllCities ()
        {
            var result = await _mediator.Send(new GetCitiesListQuery());
            return Ok(result);
        }
    }
}
