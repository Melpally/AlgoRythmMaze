using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class UserProfile
    {
        public string? GitHubProfileLink { get; set; }

        public int LevelId { get; set; }
        public Service? Level { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }

        public bool IsCourseSubscriber { get; set; } = false;
        public bool IsPremiumSubscriber { get; set; } = false;
        public bool IsInterestDetermined { get; set; } = false;

        public ICollection<CaregiverProfile>? Topics { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
