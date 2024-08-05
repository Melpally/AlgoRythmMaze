using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class TestCase
    {
        public int Id { get; set; }
        public required string Input { get; set; }
        public required string ExpectedOutput { get; set; }

        public int ChallengeId { get; set; }
        public Challenge? Challenge { get; set; }
    }
}
