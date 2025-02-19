using AlgoRythmMaze.Domain.Interfaces;
using TopiTopi.Domain.Entities;

namespace TopiTopi.Domain.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        public IQueryable<Message> GetAllMessagesFromChatAsync(int chatId);
        public Task<int> GetNewMessagesCountAsync(int chatId, int userId);
        public Task ReadAllMessagesAsync(int chatId, int userId);
    }
}
