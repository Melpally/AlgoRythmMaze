using Microsoft.AspNetCore.Mvc;
using TopiTopi.Application.Dtos.Auth;
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
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAsync(dto);

                if (result.Succeeded)
                {
                    return Ok("User registered successfully.");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(dto);

                if (result != null)
                {
                    return Ok(result);
                }
            }

            return Unauthorized("Invalid Email or Password.");
        }
    }
}
