using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AlgoRythmDbContext context) : base(context)
        {
        }
    }
}
