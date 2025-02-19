using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int CaregiverId { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Service? Service { get; set; }
        public ClientProfile? Client { get; set; }
        public CaregiverProfile? Caregiver { get; set; }

    }
}
