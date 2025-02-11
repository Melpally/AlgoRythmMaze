using AlgoRythmMaze.Domain.Entities;
using TopiTopi.Domain.Enums;

namespace AlgoRythmMaze.Domain.Models
{
    public class ClientProfile
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public string? PhotoUrl { get; set; }
        public int NumberOfChildren { get; set; }
        public CareFrequency TypeOfCare { get; set; }
        public required string About {  get; set; }
        //TODO: ranges?
        public int Rate {  get; set; }
        public required string City { get; set; }
        public bool IsPremiumSubscriber { get; set; } = false;
        //Address? or Longitude and latitude?
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Service>? ServicesNeeded { get; set; }
    }
}
