using AlgoRythmMaze.Domain.Models;

namespace TopiTopi.Domain.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CaregiverId { get; set; }
        public ClientProfile? Client { get; set; }
        public CaregiverProfile? ClientProfile { get; set; }
    }
}
