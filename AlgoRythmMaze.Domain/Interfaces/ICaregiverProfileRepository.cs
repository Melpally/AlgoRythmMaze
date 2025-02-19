using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Interfaces
{
    public interface ICaregiverProfileRepository : IBaseRepository<CaregiverProfile>
    {
        public IQueryable<CaregiverProfile> GetCaregiverProfiles(string? searchTerm, string? sortBy, bool ascending);
    }
}
