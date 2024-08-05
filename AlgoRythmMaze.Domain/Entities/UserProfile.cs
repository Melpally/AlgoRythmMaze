using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class UserProfile
    {
        public bool IsLevelDetermined { get; set; }
        public bool IsPremiumSubscriber { get; set; }

        public int LevelId { get; set; }
        public Level? Level { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }

        public ICollection<Badge>? Badges { get; set; } = [];
        public ICollection<Topic>? Topics { get; set; } = [];
        public ICollection<Interest>? Interests { get; set; } = [];
        public ICollection<LearningMaterial>? LearningMaterials { get; set; } = [];
        public ICollection<Submission>? Submissions { get; set; }
    }
}
