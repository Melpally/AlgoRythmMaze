using Microsoft.AspNetCore.Mvc;
using TopiTopi.Application.Dtos.Review;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateReview([FromForm] ReviewCreateDto dto)
        {
            var result = await _reviewService.CreateReviewAsync(dto);
            if (result)
            {
                return Ok("Review created successfully");
            }

            return BadRequest("Could not create a review");

        }

        [HttpGet("reviews/{id}")]
        public async Task<ReviewDto> GetReviewById([FromRoute] int id)
        {
            return await _reviewService.GetReviewByIdAsync(id);
        }

        [HttpGet("client/{id}/reviews")]
        public async Task<List<ReviewDto>> GetReviewsByClient([FromRoute] int id)
        {
            return await _reviewService.GetClientReviewsAsync(id);
        }

        [HttpGet("caregiver/{id}/reviews")]
        public async Task<List<ReviewDto>> GetReviewsForCaregiver([FromRoute] int id)
        {
            return await _reviewService.GetCaregiverReviewsAsync(id);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteReview([FromRoute] int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return Ok("Review deleted successfully");
        }
    }
}
