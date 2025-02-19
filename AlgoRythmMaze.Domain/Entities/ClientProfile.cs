using AlgoRythmMaze.Domain.Entities;
using TopiTopi.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class ClientProfile
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public byte[]? Photo { get; set; }
        public int NumberOfChildren { get; set; }
        public CareFrequency TypeOfCare { get; set; }
        public required string About { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public int Rate { get; set; }
        public required string City { get; set; }
        public bool IsPremiumSubscriber { get; set; } = false;
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Service>? ServicesNeeded { get; set; }
    }
}
