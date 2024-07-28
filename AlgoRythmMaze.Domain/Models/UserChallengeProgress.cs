namespace AlgoRythmMaze.Domain.Models
{
    public class UserChallengeProgress
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public required string Status { get; set; } //change to enum - Git can be offered for advanced users 
        public DateTime TimeSubmitted { get; set; }
        public required string SubmittedCode { get; set; }
        
    }
}
