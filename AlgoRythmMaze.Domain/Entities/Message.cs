using AlgoRythmMaze.Domain.Models;

namespace TopiTopi.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; } = false;
        public required string Text { get; set; }
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
        public ClientProfile? Sender { get; set; }
        public CaregiverProfile? Receiver { get; set; }
    }
}
