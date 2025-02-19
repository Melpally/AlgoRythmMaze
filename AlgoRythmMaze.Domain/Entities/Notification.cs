using AlgoRythmMaze.Domain.Models;

namespace TopiTopi.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public bool IsRead { get; set; } = false;
        public int CreatedAt { get; set; }
        public int NotificationType { get; set; }
        public Chat? Chat { get; set; }
        public User? Sender { get; set; }
        public User? Recipient { get; set; }

    }
}
