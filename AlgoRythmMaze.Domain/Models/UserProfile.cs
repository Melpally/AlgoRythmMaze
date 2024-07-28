﻿namespace AlgoRythmMaze.Domain.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public int LevelId { get; set; }
        public bool IsPremiumSubscriber { get; set; }

    }
}
