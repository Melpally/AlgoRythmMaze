using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class HintRepository : BaseRepository<Hint>, IHintRepository
    {
        public HintRepository(DbContext context) : base(context)
        {
        }
    }
}
