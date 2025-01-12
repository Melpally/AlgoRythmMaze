using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AlgoRythmDbContext context) : base(context)
        {
        }
    }
}
