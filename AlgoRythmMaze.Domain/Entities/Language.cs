using AlgoRythmMaze.Domain.Models;

namespace TopiTopi.Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<CaregiverProfile>? Caregivers { get; set; }
    }
}
