using Microsoft.AspNetCore.Identity;

namespace AlgoRythmMaze.Domain.Models
{
    public class User : IdentityUser
    {
        public required UserProfile Profile { get; set; }
    }
}
