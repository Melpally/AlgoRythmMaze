using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ProjectRepository : BaseRepository<Payment>, IProjectRepository
    {
        public ProjectRepository(DbContext context) : base(context)
        {
        }
    }
}
