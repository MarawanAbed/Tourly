using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.CityLogic.Dtos;
using TravelBookingPortal.Application.CityLogic.Queries.Models;
using TravelBookingPortal.Application.Services.CityService.Abstraction;

namespace TravelBookingPortal.API.Controllers.CityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCities ()
        {
            var result = await _mediator.Send(new GetCitiesListQuery());
            return Ok(result);
        }
    }
}
