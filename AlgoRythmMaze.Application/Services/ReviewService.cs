using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using TopiTopi.Application.Dtos.Review;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<bool> CreateReviewAsync(ReviewCreateDto dto)
        {
            var review = new Review
            {
                Text = dto.Text,
                Title = dto.Title,
                Rating = dto.Rating,
                ClientId = dto.ClientId,
                CaregiverId = dto.CaregiverId
            };


            var result = await _reviewRepository.CreateAsync(review);

            await _reviewRepository.UpdateCaregiverRatingAsync(review.CaregiverId);

            return result;
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            await _reviewRepository.DeleteAsync(reviewId);

        }

        public async Task<List<ReviewDto>> GetCaregiverReviewsAsync(int caregiverId)
        {
            var reviews = await _reviewRepository.GetReviewsByCaregiverIdAsync(caregiverId);

            return reviews.Select(r => new ReviewDto
            {
                CaregiverId = r.CaregiverId,
                CreatedAt = r.CreatedAt,
                ClientId = r.ClientId,
                Rating = r.Rating,
                Title = r.Title,
                Text = r.Text

            }).ToList();
        }

        public async Task<List<ReviewDto>> GetClientReviewsAsync(int clientId)
        {
            var reviews = await _reviewRepository.GetReviewsByClientIdAsync(clientId);

            return reviews.Select(r => new ReviewDto
            {
                CaregiverId = r.CaregiverId,
                CreatedAt = r.CreatedAt,
                ClientId = r.ClientId,
                Rating = r.Rating,
                Title = r.Title,
                Text = r.Text

            }).ToList();
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            return new ReviewDto
            {
                Text = review.Text,
                Title = review.Title,
                Rating = review.Rating,
                ClientId = review.ClientId,
                CreatedAt = review.CreatedAt,
                CaregiverId = review.CaregiverId
            };
        }
    }
}
