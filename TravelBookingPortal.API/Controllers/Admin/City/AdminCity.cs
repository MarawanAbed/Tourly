using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Admin.city.Commands.Delete;
using TravelBookingPortal.Application.Admin.city.Queries;
using TravelBookingPortal.Application.Admin.city.Commands.Create;
using TravelBookingPortal.Application.Admin.city.Commands.Update;

namespace TravelBookingPortal.API.Controllers.Admin.City
{
    [Route("Admin/")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminCityController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllCities")]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await mediator.Send(new GetAllCitiesQuery());
            return Ok(result);
        }
        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity([FromForm] CreateCityCommand command)
        {
            await mediator.Send(command);
            return Ok(new { Message = "City Created Successfully" });
        }

        [HttpDelete("DeleteCity")]

        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var command = new DeleteCityCommand { CityId = cityId };
            await mediator.Send(command);
            return Ok(new { Message = "City Deleted Successfully" });

        }

        [HttpPut("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromForm] UpdateCityCommand command)
        {
            await mediator.Send(command);
            return Ok(new { Message = "City Updated Successfully" });

        }
    }
}
