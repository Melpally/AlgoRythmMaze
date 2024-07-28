namespace AlgoRythmMaze.Domain.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string TestCases { get; set; }
        public required string SolutionScript { get; set; } // do I really need it?
        
    }
}
