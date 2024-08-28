using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public int ReviewCount { get; set; }
        public string? PhotoUrl { get; set; }
        public float AverageRating { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public ICollection<Topic>? Topics { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
