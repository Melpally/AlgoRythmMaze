﻿namespace AlgoRythmMaze.Domain.Models
{
    public class Hint
    {
        public int Id {  get; set; }
        public required string Text { get; set; }
        public int ChallengeId { get; set; }

    }
}
