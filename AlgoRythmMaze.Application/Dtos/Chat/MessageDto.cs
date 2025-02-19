namespace TopiTopi.Application.Dtos.Chat
{
    public class MessageDto
    {
        public required string Text { get; set; }
        public DateTime SentAt { get; set; }
        public int SenderId { get; set; }
        public bool IsRead { get; set; }
    }
}
