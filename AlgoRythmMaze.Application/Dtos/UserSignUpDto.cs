using AlgoRythmMaze.Domain.Enums;

namespace AlgoRythmMaze.Application.Dtos
{
    public class UserSignUpDto
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRole UserRole { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
