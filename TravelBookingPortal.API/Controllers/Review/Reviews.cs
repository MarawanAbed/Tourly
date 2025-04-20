using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBookingPortal.Application.Reviews.Commands.CreateReview;
using TravelBookingPortal.Application.Reviews.Commands.DeleteReview;
using TravelBookingPortal.Application.Reviews.Commands.UpdateReview;
using TravelBookingPortal.Application.Reviews.Queries.GetReviewByUser;
using TravelBookingPortal.Application.Reviews.Queries.GetReviewsByHotel;


namespace TravelBookingPortal.API.Controllers.Review
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
        {
            
            await _mediator.Send(command);
            return Ok(new { message = "Review created successfully." });
        }

        [HttpGet("my/{userId}")]
        public async Task<IActionResult> GetUserReviews(string userId)
        {
            var result = await _mediator.Send(new GetReviewsByUserQuery { UserId = userId });
            return Ok(result);
        }

        [HttpGet("hotel/{hotelName}")]
        public async Task<IActionResult> GetHotelReviews(string hotelName)
        {
            var result = await _mediator.Send(new GetReviewsByHotelQuery { HotelName = hotelName });
            return Ok(result);
        }

        [HttpDelete("Delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            await _mediator.Send(new DeleteReviewCommand { ReviewId = reviewId });
            return Ok(new { message = "Review deleted successfully." });
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] UpdateReviewCommand command)
        {
            if (reviewId != command.ReviewId)
                return BadRequest(" There are wrong , Mismatch between route and body.");

            await _mediator.Send(command);
            return Ok(new { message = "Review updated successfully." });
        }


    }
}