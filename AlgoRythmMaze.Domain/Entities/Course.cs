using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public float Discount { get; set; }
        public string? Skills { get; set; }
        public required string Name { get; set; }
        public int NumberOfSubscribers { get; set; }
        public required string Description { get; set; }
        
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Challenge>? Challenges { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
        public ICollection<LearningMaterial>? LearningMaterials { get; set; }
    }
}
