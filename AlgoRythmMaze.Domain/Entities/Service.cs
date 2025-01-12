using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UserProfile>? UserProfiles { get; set; }
    }
}
