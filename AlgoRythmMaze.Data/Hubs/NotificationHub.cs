using Microsoft.AspNetCore.SignalR;
using TopiTopi.Application.Dtos.Chat;
using TopiTopi.Application.Interfaces;
using TopiTopi.Domain.Entities;

namespace TopiTopi.Infrastructure.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IMessageService _messageService;

        public NotificationHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task ConnectAsync(int chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        }

        public async Task SendMessageAsync(MessageCreateDto dto)
        {
            await _messageService.CreateAsync(dto);
            await Clients.Group(dto.ChatId.ToString()).SendAsync("Receive message", dto);
        }

        public async Task ReadAllMessagesAsync(int chatId, int senderId)
        {
            await _messageService.ReadAllMessagesAsync(chatId, senderId);
            await Clients.Group(chatId.ToString()).SendAsync("OnReadAllMessage", senderId);
        }

        public async Task SendNotification(Notification notification)
        {
            await Clients.User(notification.RecipientId.ToString()).SendAsync("ReceiveNotification", notification);
        }
    }
}
