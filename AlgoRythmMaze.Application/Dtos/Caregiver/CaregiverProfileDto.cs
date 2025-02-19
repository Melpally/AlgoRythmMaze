using AlgoRythmMaze.Application.Dtos;
using AlgoRythmMaze.Domain.Enums;
using TopiTopi.Domain.Enums;

namespace TopiTopi.Application.Dtos.Caregiver
{
    public class CaregiverProfileDto
    {
        public byte[]? Photo { get; set; }
        public byte[]? ProfessionalReferences { get; set; }
        public byte[]? ProfessionalCertificate { get; set; }
        public required string WorkPhoneNumber { get; set; }
        public required string AboutMe { get; set; }
        public Gender Gender { get; set; }
        public float AverageRating { get; set; }
        public required string City { get; set; }
        public int HourlyRateUZS { get; set; }
        public int Age { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public ICollection<ServiceDto>? Services { get; set; }
    }
}
