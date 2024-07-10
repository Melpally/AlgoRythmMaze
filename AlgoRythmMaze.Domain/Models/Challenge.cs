namespace AlgoRythmMaze.Domain.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Difficulty { get; set; } // how to establish - objective measure
        public required string Description { get; set; }
        public required string TestCases { get; set; }
        
    }
}
