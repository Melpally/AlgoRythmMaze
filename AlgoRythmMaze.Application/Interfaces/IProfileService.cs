using TopiTopi.Application.Dtos.Caregiver;
using TopiTopi.Application.Dtos.Client;
using TopiTopi.Application.Helpers;

namespace TopiTopi.Application.Interfaces
{
    public interface IProfileService
    {
        public Task<bool> CompleteCaregiverProfileAsync(CaregiverProfileCreateDto dto);
        public Task<bool> CompleteClientProfileAsync(ClientProfileCreateDto dto);
        public Task<PagedResult<CaregiverProfileDto>> GetFilteredCaregiversAsync(string? searchTerm, string? sortBy, bool ascending, int pageNumber, int pageSize);
        public Task<PagedResult<CaregiverProfileUnverifiedDto>> GetUnverifiedCaregiverProfilesAsync(int pageNumber, int pageSize);
        public Task EditCaregiverProfileAsync(int id, CaregiverProfileDto dto);
    }
}
