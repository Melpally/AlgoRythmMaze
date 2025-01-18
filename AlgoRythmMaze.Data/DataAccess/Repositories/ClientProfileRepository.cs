using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class ClientProfileRepository : BaseRepository<ClientProfile>, IClientProfileRepository
    {
        public ClientProfileRepository(DbContext context) : base(context)
        {
        }
    }
}
