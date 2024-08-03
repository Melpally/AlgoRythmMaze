using AlgoRythmMaze.Domain.Entities;

namespace AlgoRythmMaze.Domain.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ICollection<TestCase> TestCases { get; set; }
        public required string SolutionScript { get; set; }  
    }
}
