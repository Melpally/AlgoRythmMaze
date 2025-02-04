using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class CaregiverProfileRepository : BaseRepository<CaregiverProfile>, ICaregiverProfileRepository
    {
        public CaregiverProfileRepository(DataContext context) : base(context)
        {
        }
    }
}
