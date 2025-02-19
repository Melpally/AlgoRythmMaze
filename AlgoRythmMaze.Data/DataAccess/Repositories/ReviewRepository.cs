using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context)
        {
        }

        public async Task UpdateCaregiverRatingAsync(int caregiverId)
        {
            var avgRating = await _context.Reviews
                                  .AsNoTracking()
                                  .Where(r => r.CaregiverId == caregiverId)
                                  .Select(r => (float?)r.Rating)
                                  .AverageAsync() ?? 0;

            var caregiver = await _context.CaregiverProfiles.FindAsync(caregiverId);

            if (caregiver != null)
            {
                caregiver.AverageRating = avgRating;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Review>> GetReviewsByCaregiverIdAsync(int caregiverId)
        {
            return await _context.Reviews
                  .AsNoTracking()
                  .Where(r => r.CaregiverId == caregiverId)
                  .ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByClientIdAsync(int clientId)
        {
            return await _context.Reviews
                  .AsNoTracking()
                  .Where(r => r.ClientId == clientId)
                  .ToListAsync();
        }
    }
}
