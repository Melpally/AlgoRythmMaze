using AlgoRythmMaze.Infrastructure.Data;
using AlgoRythmMaze.Infrastructure.DataAccess.Repositories;
using TopiTopi.Domain.Entities;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Infrastructure.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(DataContext context) : base(context)
        {
        }

    }
}
