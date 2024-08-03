namespace AlgoRythmMaze.Domain.Models
{
    /// <summary>
    /// For the user to keep track of how many XPs they gained across the range of topics.
    /// </summary>
    public class TopicXP
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public int XP { get; set; }
    }
}
