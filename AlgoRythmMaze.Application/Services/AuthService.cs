using AlgoRythmMaze.Application.Dtos;
using AlgoRythmMaze.Domain.Enums;
using AlgoRythmMaze.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthService> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;

        }

        public async Task<string?> LoginAsync(UserLoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User {dto.Email} logged in successfully.");
                return "Login successful.";
            }

            if (result.IsNotAllowed)
            {
                _logger.LogWarning($"Login failed for {dto.Email}: Email is not confirmed.");
                return "Email not confirmed.";
            }

            _logger.LogWarning($"Failed login attempt for user {dto.Email}.");

            return null;
        }

        public async Task<IdentityResult> RegisterAsync(UserSignUpDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserRole = dto.UserRole
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, dto.UserRole == UserRole.Caregiver ? "Caregiver" : "CareSeeker");
            }

            return result;
        }




        public Task CreateTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendEmailNotificationAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task VerifyEmailAsync(string userToken, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
