using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Reviews.Commands;
using TravelBookingPortal.Application.Reviews.DTOs;
using TravelBookingPortal.Application.Reviews.Queries;

namespace TravelBookingPortal.API.Controllers.ReviewController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            var command = new CreateReviewCommand { ReviewDto = dto };
            await _mediator.Send(command);
            return Ok(new { message = "Review created successfully." });
        }

        [HttpGet("my/{userId}")]
        public async Task<IActionResult> GetUserReviews(string userId)
        {
            var result = await _mediator.Send(new GetReviewsByUserQuery { UserId = userId });
            return Ok(result);
        }
    }
}