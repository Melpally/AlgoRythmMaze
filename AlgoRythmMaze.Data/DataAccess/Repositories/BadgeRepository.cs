using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class BadgeRepository : BaseRepository<Badge>, IBadgeRepository
    {
        public BadgeRepository(AlgoRythmDbContext context) : base(context)
        {
        }
    }
}
