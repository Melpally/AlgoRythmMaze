namespace AlgoRythmMaze.Domain.Models
{
    public class UserChallengeProgress
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public required string Status { get; set; } //change to enum - why do we need the status? Will it be similar to git or 21? but no integration with git? - Git can be offered for advanced users 
        public DateTime TimeSubmitted { get; set; }
        public required string SubmittedCode { get; set; }
        
    }
}
