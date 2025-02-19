using AlgoRythmMaze.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace TopiTopi.Application.Dtos.Auth
{
    public class UserSignUpDto
    {
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(maximumLength: 200, ErrorMessage = "The name is too short or too long", MinimumLength = 4)]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format. ")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be no shorter than 8 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase, one lowercase, one digit, and one special character.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public required string PhoneNumber { get; set; }

        public UserRole UserRole { get; set; }
    }
}
