using AlgoRythmMaze.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] UserSignUpDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized("Invalid Email or Password.");
        }
    }
}
