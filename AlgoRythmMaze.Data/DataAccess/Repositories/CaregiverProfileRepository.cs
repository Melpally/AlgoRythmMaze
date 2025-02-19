using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class CaregiverProfileRepository : BaseRepository<CaregiverProfile>, ICaregiverProfileRepository
    {
        public CaregiverProfileRepository(DataContext context) : base(context)
        {
        }

        public IQueryable<CaregiverProfile> GetCaregiverProfiles(string? searchTerm, string? sortBy, bool ascending)
        {
            var query = _context.CaregiverProfiles
                        .AsNoTracking()
                        .Where(c => c.IsVerified);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c =>
                              c.FirstName.Contains(searchTerm) ||
                              c.City.Contains(searchTerm));
            }

            query = sortBy switch
            {
                "name" => ascending ? query.OrderBy(c => c.FirstName) : query.OrderByDescending(c => c.FirstName),
                "rating" => ascending ? query.OrderBy(c => c.AverageRating) : query.OrderByDescending(c => c.AverageRating),
                _ => query.OrderBy(c => c.FirstName)
            };

            return query;
        }
    }
}
