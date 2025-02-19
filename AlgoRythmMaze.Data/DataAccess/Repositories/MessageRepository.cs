using AlgoRythmMaze.Infrastructure.Data;
using AlgoRythmMaze.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using TopiTopi.Domain.Entities;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Infrastructure.DataAccess.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(DataContext context) : base(context)
        {
        }
        public IQueryable<Message> GetAllMessagesFromChatAsync(int chatId)
        {
            return _context.Messages
                .AsNoTracking()
                .Where(m => m.ChatId == chatId);
        }

        public async Task<int> GetNewMessagesCountAsync(int chatId, int userId)
        {
            return await _context.Messages
                .AsNoTracking()
                .CountAsync(m =>
                    m.ChatId == chatId &&
                    m.ReceiverId == userId &&
                    !m.IsRead);

        }

        public async Task ReadAllMessagesAsync(int chatId, int userId)
        {
            await _context.Messages
                .Where(m =>
                    m.ChatId == chatId &&
                    m.ReceiverId == userId &&
                    !m.IsRead)
                .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(m => m.IsRead, true));
        }
    }
}
