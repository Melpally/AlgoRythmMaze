using TopiTopi.Domain.Enums;

namespace TopiTopi.Application.Dtos.Client
{
    public class ClientProfileDto
    {
        public int Id { get; set; }
        public byte[]? Photo { get; set; }
        public int NumberOfChildren { get; set; }
        public CareFrequency TypeOfCare { get; set; }
        public required string About { get; set; }
        public int Rate { get; set; }
        public required string City { get; set; }
        public bool IsPremiumSubscriber { get; set; } = false;
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public ICollection<int>? ServicesNeeded { get; set; }
    }
}
