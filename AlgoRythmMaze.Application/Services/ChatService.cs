using TopiTopi.Application.Dtos.Chat;
using TopiTopi.Application.Exceptions;
using TopiTopi.Application.Interfaces;
using TopiTopi.Domain.Entities;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task CreateAsync(ChatCreateDto dto)
        {
            var chat = new Chat
            {
                CaregiverId = dto.CaregiverId,
                ClientId = dto.ClientId
            };

            await _chatRepository.CreateAsync(chat);
        }

        public async Task<ChatDto> GetChatAsync(int chatId)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId) ?? throw new InvalidInputException("Chat with the given Id was not found.");
            var chatDto = new ChatDto
            {
                Id = chat.Id,
                ClientId = chat.ClientId,
                CaregiverId = chat.CaregiverId
            };

            return chatDto;
        }

    }
}
