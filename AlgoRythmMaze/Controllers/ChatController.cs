using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TopiTopi.Application.Dtos.Chat;
using TopiTopi.Application.Exceptions;
using TopiTopi.Application.Interfaces;
using TopiTopi.Infrastructure.Hubs;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IMessageService _messageService;
        private readonly IChatService _chatService;

        public ChatController(IHubContext<NotificationHub> hubContext, IMessageService messageService, IChatService chatService)
        {
            _hubContext = hubContext;
            _chatService = chatService;
            _messageService = messageService;

        }

        [HttpGet("chat/{id}")]
        public async Task<ActionResult> GetAllMessagesByChatId([FromRoute] int id)
        {
            try
            {
                var messages = await _messageService.GetAllMessagesAsync(id);
                return Ok(messages);
            }
            catch (InvalidInputException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateChatAsync([FromForm] ChatCreateDto dto)
        {
            try
            {
                await _chatService.CreateAsync(dto);
                return Ok("Chat created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
