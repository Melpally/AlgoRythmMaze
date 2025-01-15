using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int ClientId { get; set; }
        public int CaregiverId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Text { get; set; }
        public ClientProfile? Client { get; set; }
        public CaregiverProfile? Caregiver { get; set; }
    }
}
