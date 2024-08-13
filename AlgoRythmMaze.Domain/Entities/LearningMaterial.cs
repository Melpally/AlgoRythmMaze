using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class LearningMaterial
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public Format Format { get; set; }
        public int OrderNumber { get; set; }
        public string? Text { get; set; }
        public string? VideoUrl { get; set; }
        public string? PhotoUrl { get; set; }
      
        public ICollection<Course>? Courses { get; set;}
    }
}
