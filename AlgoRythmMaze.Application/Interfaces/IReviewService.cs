using TopiTopi.Application.Dtos.Review;

namespace TopiTopi.Application.Interfaces
{
    public interface IReviewService
    {
        public Task<List<ReviewDto>> GetCaregiverReviewsAsync(int caregiverId);
        public Task<List<ReviewDto>> GetClientReviewsAsync(int clientId);
        public Task<bool> CreateReviewAsync(ReviewCreateDto dto);
        public Task<ReviewDto> GetReviewByIdAsync(int reviewId);
        public Task DeleteReviewAsync(int reviewId);

    }
}
