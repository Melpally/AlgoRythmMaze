using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public int CaregiverId { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Service? Service { get; set; }
        public ClientProfile? Client { get; set; }
        public CaregiverProfile? Caregiver { get; set; }
        /// <summary>
        /// TODO: Booking should have its own status similar to - care has been provided or agreed to provide in the future etc
        /// </summary>
        public Status Status { get; set; }

    }
}
