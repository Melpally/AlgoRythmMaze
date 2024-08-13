namespace AlgoRythmMaze.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Text { get; set; }
    }
}
