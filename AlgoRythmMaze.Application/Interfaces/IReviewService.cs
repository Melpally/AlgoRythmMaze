using TopiTopi.Application.Dtos.Review;

namespace TopiTopi.Application.Interfaces
{
    public interface IReviewService
    {
        public Task<bool> CreateReviewAsync(ReviewCreateDto dto);
        public Task<ReviewDto> GetReviewByIdAsync(int reviewId);
        public Task UpdateReviewAsync(int reviewId);
        public Task DeleteReviewAsync(int reviewId);
        public Task<ICollection<ReviewDto>> GetCaregiverReviewsAsync(int caregiverId);
        public Task<ICollection<ReviewDto>> GetClientReviewsAsync(int clientId);
        public Task<float> GetCaregiverAverageRatingAsync(int caregiverId);

    }
}
