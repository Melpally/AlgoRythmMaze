using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<string?> GetNameByIdAsync(int id)
        {
            return await _context.Users
                    .AsNoTracking()
                    .Where(u => u.Id == id)
                    .Select(u => u.FullName)
                    .FirstOrDefaultAsync();
        }
    }
}
