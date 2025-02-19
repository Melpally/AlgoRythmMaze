using TopiTopi.Application.Dtos.Chat;

namespace TopiTopi.Application.Interfaces
{
    public interface IChatService
    {
        public Task CreateAsync(ChatCreateDto dto);
        public Task<ChatDto> GetChatAsync(int chatId);
    }
}
