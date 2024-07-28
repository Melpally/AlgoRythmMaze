namespace AlgoRythmMaze.Domain.Models
{
    public class LearningMaterial
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int OrderNumber { get; set; }
        public required string Text { get; set; }
    }
}
