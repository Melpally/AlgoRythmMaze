using System.ComponentModel.DataAnnotations;

namespace TopiTopi.Application.Dtos.Auth
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }
}
