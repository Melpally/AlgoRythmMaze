using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class CaregiverProfile
    {
        public List<Service>? ServicesProvided { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }
        public bool IsPremiumSubscriber { get; set; } = false;

        public ICollection<CaregiverProfile>? Profile { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
