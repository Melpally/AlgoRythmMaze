using Microsoft.AspNetCore.Identity;
using TopiTopi.Application.Dtos.Auth;

namespace TopiTopi.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> RegisterAsync(UserSignUpDto dto);
        public Task<string?> LoginAsync(UserLoginDto dto);
        public Task VerifyEmailAsync(string userToken, CancellationToken cancellationToken);

        /// <summary>
        /// Creates an authentication token for the user.
        /// </summary>
        /// <param name="user">User's login information.</param>
        /// <param name="roleName">The user's role name.</param>
        /// <returns>A string representing the generated token.</returns>
        public Task CreateTokenAsync();
        public Task ForgotPasswordAsync(string email);
        public Task ResetPasswordAsync();
        /// <summary>
        /// Sends a confirmation link to user, if the email address is not already confirmed.
        /// </summary>
        /// <param name="email">The email address of the user</param>
        public Task SendEmailNotificationAsync(string email);
    }
}
