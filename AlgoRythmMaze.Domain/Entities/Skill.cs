using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Skill
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<CaregiverProfile>? Profiles { get; set; }
    }
}
