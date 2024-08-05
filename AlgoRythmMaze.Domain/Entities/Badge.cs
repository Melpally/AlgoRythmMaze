namespace AlgoRythmMaze.Domain.Models
{
    public class Badge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UserProfile>? Users { get; set; } = [];
    }
}
