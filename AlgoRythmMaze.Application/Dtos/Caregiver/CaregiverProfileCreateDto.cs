using AlgoRythmMaze.Application.Dtos;
using System.ComponentModel.DataAnnotations;
using TopiTopi.Application.Attributes;
using TopiTopi.Domain.Enums;

namespace TopiTopi.Application.Dtos.Caregiver
{
    public class CaregiverProfileCreateDto
    {
        public byte[]? Photo { get; set; }
        public byte[]? PassportCopy { get; set; }
        public byte[]? CertificateOfNonConviction { get; set; }
        public byte[]? ProfessionalReferences { get; set; }
        public byte[]? ProfessionalCertificate { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public required string WorkPhoneNumber { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The text should not exceed 500 characters.")]
        public required string AboutMe { get; set; }
        public Gender Gender { get; set; }
        public required string City { get; set; }
        public int HourlyRateUZS { get; set; }

        [Required]
        [Age(18)]
        public DateTime DoB { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public ICollection<ServiceDto>? Services { get; set; }
    }
}
