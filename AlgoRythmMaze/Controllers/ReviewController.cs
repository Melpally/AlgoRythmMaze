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

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewCreateDto dto)
        {
            var result = await _reviewService.CreateReviewAsync(dto);
            if (result)
            {
                return Ok("Review created successfully");
            }

            return BadRequest("Could not create a review");

        }
    }
}
