using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class UserProfile
    {
        public int LevelId { get; set; }
        public Level? Level { get; set; }

        public int UserId { get; set; }
        public required User User { get; set; }
                
        public bool IsCourseSubscriber { get; set; } = false;
        public bool IsPremiumSubscriber { get; set; } = false;
        public bool IsInterestDetermined { get; set; } = false;

        public ICollection<Badge>? Badges { get; set; }
        public ICollection<Topic>? Topics { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Interest>? Interests { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
    }
}
