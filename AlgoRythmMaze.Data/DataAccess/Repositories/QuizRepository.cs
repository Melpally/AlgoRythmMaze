using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using AlgoRythmMaze.Infrastructure.Data;

namespace AlgoRythmMaze.Infrastructure.DataAccess.Repositories
{
    public class QuizRepository : BaseRepository<CaregiverProfile>, IQuizRepository
    {
        public QuizRepository(DbContext context) : base(context)
        {
        }
    }
}
