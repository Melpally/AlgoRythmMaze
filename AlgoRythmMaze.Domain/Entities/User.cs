using AlgoRythmMaze.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace AlgoRythmMaze.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public required string FullName { get; set; }
        public required UserRole UserRole { get; set; }
        public ClientProfile? ClientProfile { get; set; }
        public CaregiverProfile? CaregiverProfile { get; set; }
    }
}
