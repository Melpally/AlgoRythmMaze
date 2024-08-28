using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class CourseMaterialRepository : BaseRepository<CourseMaterial>, ICourseMaterialRepository
    {
        public CourseMaterialRepository(AlgoRythmDbContext context) : base(context)
        {
        }
    }
}
