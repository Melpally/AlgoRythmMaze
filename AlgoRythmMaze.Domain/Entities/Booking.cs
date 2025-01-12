namespace AlgoRythmMaze.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int MaxLevelXp { get; set; }
        public ICollection<CaregiverProfile>? Quizzes { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
