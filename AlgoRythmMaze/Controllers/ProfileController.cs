using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopiTopi.Application.Dtos.Caregiver;
using TopiTopi.Application.Dtos.Client;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("/get")]
        public async Task<ActionResult> GetCaregiverProfiles([FromQuery] string? searchTerm, [FromQuery] string? sortBy, [FromQuery] bool ascending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                pageNumber = 1;
                pageSize = 10;
            }
            var result = await _profileService.GetFilteredCaregiversAsync(searchTerm, sortBy, ascending, pageNumber, pageSize);
            return Ok(result);

        }

        [HttpPost("caregiver/create")]
        [Authorize(Roles = "Caregiver")]
        public async Task<ActionResult> CreateCaregiverProfile([FromForm] CaregiverProfileCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileService.CompleteCaregiverProfileAsync(dto);

                if (result)
                {
                    return Ok("The caregiver profile was successfully created.");
                }

            }
            return BadRequest(ModelState);

        }

        [HttpPost("client/create")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> CreateClientProfile([FromForm] ClientProfileCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _profileService.CompleteClientProfileAsync(dto);

                if (result)
                {
                    return Ok("The client profile was successfully created.");
                }
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("admin/caregivers/{id}/verify")]
        public Task VerifyCaregiverProfile([FromRoute] int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("unverified/profiles")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetUnverifiedCaregiverProfiles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                pageNumber = 1;
                pageSize = 10;
            }
            var result = await _profileService.GetUnverifiedCaregiverProfilesAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
