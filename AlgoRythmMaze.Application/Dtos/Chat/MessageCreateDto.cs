namespace TopiTopi.Application.Dtos.Chat
{
    public class MessageCreateDto
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime SentAt { get; set; }
        public required string Text { get; set; }

    }
}
