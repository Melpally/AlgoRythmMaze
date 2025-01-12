using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }
    }
}
