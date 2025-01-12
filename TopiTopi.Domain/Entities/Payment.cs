using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public required string Title { get; set; }
        public required string RepositoryLink { get; set; }

        public ICollection<Hint>? Hints { get; set; }
        public ICollection<CaregiverProfile> Topics { get; set; } = new List<CaregiverProfile>();
    }
}
