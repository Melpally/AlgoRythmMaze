using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public bool IsLevelDetermined { get; set; } //default is false
        public bool IsPremiumSubscriber { get; set; }
        public int LevelId { get; set; }
        public int LearningMaterialId { get; set; }
        
    }
}
