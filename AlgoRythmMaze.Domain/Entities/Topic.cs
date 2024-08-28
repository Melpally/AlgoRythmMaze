namespace AlgoRythmMaze.Domain.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Quiz>? Quizzes { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
