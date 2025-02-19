using TopiTopi.Application.Dtos.Chat;
using TopiTopi.Domain.Entities;

namespace TopiTopi.Application.Interfaces
{
    public interface IMessageService
    {
        public Task<Message> CreateAsync(MessageCreateDto dto);
        public Task<List<MessageDto>> GetAllMessagesAsync(int chatId);
        public Task<int> GetNewMessagesCountAsync(int chatId, int userId);
        public Task ReadAllMessagesAsync(int chatId, int userId);
    }
}
