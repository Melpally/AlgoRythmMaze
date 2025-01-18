using Microsoft.AspNetCore.Mvc;

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


        // POST api/<AuthController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserSignUpDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result != null)
            {
                Ok(result);
            }

            return Unauthorized("Invalid Email or Password.");
        }
    }
}
