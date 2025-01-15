using AlgoRythmMaze.Domain.Models;

namespace AlgoRythmMaze.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<CaregiverProfile>? Caregivers { get; set; }
        public ICollection<ClientProfile>? Clients { get; set; }
    }
}
