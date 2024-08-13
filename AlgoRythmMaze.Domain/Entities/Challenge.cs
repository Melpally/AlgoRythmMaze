using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public QuestionType Type { get; set; }
        public string? Materials { get; set; } //TODO: enhance
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string SolutionScript { get; set; }

        public ICollection<Hint>? Hints { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public ICollection<TestCase>? TestCases { get; set; }
        public ICollection<Submission>? Submissions { get; set; }
        public ICollection<Topic> Topics { get; } = new List<Topic>();
    }
}
