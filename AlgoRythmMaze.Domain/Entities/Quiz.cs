using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public required string Title { get; set; }
        public required string Answer { get; set; }
        public required string Question { get; set; }
        public QuestionType QuestionType { get; set; }

        public int LevelId { get; set; }
        public Level? Level { get; set; }

        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
