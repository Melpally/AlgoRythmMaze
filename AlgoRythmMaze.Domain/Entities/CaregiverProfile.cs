﻿using AlgoRythmMaze.Domain.Entities;
using AlgoRythmMaze.Domain.Enums;
using TopiTopi.Domain.Entities;
using TopiTopi.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class CaregiverProfile
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public string? PhotoUrl { get; set; }
        public required string WorkPhoneNumber { get; set; }
        public required string AboutMe { get; set; }
        public Gender Gender { get; set; }
        public required string City { get; set; }
        public int HourlyRateUZS { get; set; }
        public DateTime DoB { get; set; }
        public Status Status { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public ICollection<Skill>? Skills { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Service>? Services { get; set; }
        public ICollection<Language>? Languages { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
        public bool IsPremiumSubscriber { get; set; } = false;
    }
}
