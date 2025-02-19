using Microsoft.EntityFrameworkCore;
using TopiTopi.Application.Dtos.Chat;
using TopiTopi.Application.Exceptions;
using TopiTopi.Application.Interfaces;
using TopiTopi.Domain.Entities;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatRepository _chatRepository;
        public MessageService(IMessageRepository messageRepository, IChatRepository chatRepository)
        {
            _messageRepository = messageRepository;
            _chatRepository = chatRepository;
        }

        public async Task<Message> CreateAsync(MessageCreateDto dto)
        {
            _ = await _chatRepository.GetByIdAsync(dto.ChatId) ?? throw new InvalidInputException("The chat with the given Id does not exist.");
            var message = new Message
            {
                Text = dto.Text,
                ChatId = dto.ChatId,
                ReceiverId = dto.ReceiverId,
                SenderId = dto.SenderId
            };

            await _messageRepository.CreateAsync(message);
            return message;
        }

        public async Task<List<MessageDto>> GetAllMessagesAsync(int chatId)
        {
            var chat = await _chatRepository.GetByIdAsync(chatId) ?? throw new InvalidInputException("The chat with the given Id doesn't exist.");
            var query = _messageRepository.GetAllMessagesFromChatAsync(chatId);
            var messages = await query
                .Select(m => new MessageDto
                {
                    Text = m.Text,
                    IsRead = m.IsRead,
                    SenderId = m.SenderId,
                    SentAt = m.SentAt
                })
                .ToListAsync();
            return messages;
        }

        public async Task<int> GetNewMessagesCountAsync(int chatId, int userId)
        {
            var count = await _messageRepository.GetNewMessagesCountAsync(chatId, userId);
            return count;
        }

        public async Task ReadAllMessagesAsync(int chatId, int userId)
        {
            await _messageRepository.ReadAllMessagesAsync(chatId, userId);
        }
    }
}
