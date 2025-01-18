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

            return result;
        }

        public Task DeleteReviewAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task<float> GetCaregiverAverageRatingAsync(int caregiverId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ReviewDto>> GetCaregiverReviewsAsync(int caregiverId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ReviewDto>> GetClientReviewsAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewDto> GetReviewByIdAsync(int reviewId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReviewAsync(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
