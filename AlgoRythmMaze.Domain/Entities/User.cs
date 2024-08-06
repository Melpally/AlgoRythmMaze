using Microsoft.AspNetCore.Identity;

namespace AlgoRythmMaze.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public required UserProfile Profile { get; set; }
    }
}
