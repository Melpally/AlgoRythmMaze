﻿namespace TopiTopi.Application.Dtos.Review
{
    public class ReviewCreateDto
    {
        public int Rating { get; set; }
        public int ClientId { get; set; }
        public int CaregiverId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Text { get; set; }
        public required string Title { get; set; }

    }
}
