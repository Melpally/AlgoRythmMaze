using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ChallengeRepository : BaseRepository<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(AlgoRythmDbContext context) : base(context)
        {
        }
    }
}
