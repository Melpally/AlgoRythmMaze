﻿using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string? Result { get; set; }
        public int AttemptCount { get; set; } = 0;
        public DateTime TimeSubmitted { get; set; }
        public required string SubmittedCode { get; set; }

        public int UserId { get; set; }
        public UserProfile? User { get; set; }

        public int ChallengeId { get; set; }
        public Challenge? Challenge { get; set; }
    }
}
