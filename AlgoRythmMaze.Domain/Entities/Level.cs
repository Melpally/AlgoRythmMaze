namespace AlgoRythmMaze.Domain.Models
{
    public class Level
    {
        public int Id { get; set; }
        public int MaxLevelXp { get; set; }
        public ICollection<Quiz>? Quizzes { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
