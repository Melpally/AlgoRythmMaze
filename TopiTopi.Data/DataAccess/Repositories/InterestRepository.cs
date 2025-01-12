using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class InterestRepository : BaseRepository<Interest>, IInterestRepository
    {
        public InterestRepository(DbContext context) : base(context)
        {
        }
    }
}
