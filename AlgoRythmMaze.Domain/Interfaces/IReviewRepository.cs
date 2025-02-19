using AlgoRythmMaze.Domain.Entities;


namespace AlgoRythmMaze.Domain.Interfaces
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        public Task UpdateCaregiverRatingAsync(int caregiverId);
        public Task<List<Review>> GetReviewsByCaregiverIdAsync(int caregiverId);
        public Task<List<Review>> GetReviewsByClientIdAsync(int clientId);
    }
}
