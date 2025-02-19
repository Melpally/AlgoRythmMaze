using AlgoRythmMaze.Application.Dtos;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using Microsoft.EntityFrameworkCore;
using TopiTopi.Application.Dtos.Caregiver;
using TopiTopi.Application.Dtos.Client;
using TopiTopi.Application.Helpers;
using TopiTopi.Application.Interfaces;

namespace TopiTopi.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ICaregiverProfileRepository _caregiverRepository;
        private readonly IClientProfileRepository _clientProfileRepository;

        public ProfileService(ICaregiverProfileRepository caregiverProfile, IClientProfileRepository clientProfileRepository)
        {
            _caregiverRepository = caregiverProfile;
            _clientProfileRepository = clientProfileRepository;

        }

        public async Task<bool> CompleteCaregiverProfileAsync(CaregiverProfileCreateDto dto)
        {
            var caregiver = new CaregiverProfile
            {
                AboutMe = dto.AboutMe,
                PassportCopy = dto.PassportCopy,
                CertificateOfNonConviction = dto.CertificateOfNonConviction,
                ProfessionalCertificate = dto.ProfessionalCertificate,
                ProfessionalReferences = dto.ProfessionalReferences,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                City = dto.City,
                DoB = dto.DoB,
                Photo = dto.Photo,
                Gender = dto.Gender,
                HourlyRateUZS = dto.HourlyRateUZS,
                WorkPhoneNumber = dto.WorkPhoneNumber
            };

            return await _caregiverRepository.CreateAsync(caregiver);

        }

        public async Task<bool> CompleteClientProfileAsync(ClientProfileCreateDto dto)
        {
            var client = new ClientProfile
            {
                About = dto.About,
                City = dto.City,
                Latitude = dto.Longitude,
                Longitude = dto.Longitude,
                NumberOfChildren = dto.NumberOfChildren,
                TypeOfCare = dto.TypeOfCare,
                Rate = dto.Rate,
                Photo = dto.Photo
            };

            return await _clientProfileRepository.CreateAsync(client);
        }

        public async Task EditCaregiverProfileAsync(int id, CaregiverProfileDto dto)
        {
            var caregiver = await _caregiverRepository.GetByIdAsync(id);

            caregiver.AboutMe = dto.AboutMe;
            caregiver.ProfessionalCertificate = dto.ProfessionalCertificate;
            caregiver.ProfessionalReferences = dto.ProfessionalReferences;
            caregiver.Latitude = dto.Latitude;
            caregiver.Longitude = dto.Longitude;
            caregiver.City = dto.City;
            caregiver.Photo = dto.Photo;
            caregiver.HourlyRateUZS = dto.HourlyRateUZS;
            caregiver.WorkPhoneNumber = dto.WorkPhoneNumber;

            await _caregiverRepository.UpdateAsync(caregiver);
        }

        public void EditClientProfileAsync(int id)
        {

        }


        public async Task<PagedResult<CaregiverProfileDto>> GetFilteredCaregiversAsync(
            string? searchTerm,
            string? sortBy,
            bool ascending,
            int pageNumber,
            int pageSize)
        {
            var query = _caregiverRepository.GetCaregiverProfiles(searchTerm, sortBy, ascending);

            var totalCount = await query.CountAsync();
            var caregivers = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new CaregiverProfileDto
                    {
                        AboutMe = c.AboutMe,
                        Age = DateTime.Now.Year - c.DoB.Year,
                        AverageRating = c.AverageRating,
                        City = c.City,
                        Services = c.Services.Select(s => new ServiceDto
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).ToList(),
                        Gender = c.Gender,
                        HourlyRateUZS = c.HourlyRateUZS,
                        Latitude = c.Latitude,
                        Longitude = c.Longitude,
                        WorkPhoneNumber = c.WorkPhoneNumber,
                        Photo = c.Photo
                    })
                    .ToListAsync();

            return new PagedResult<CaregiverProfileDto>(caregivers, totalCount, pageNumber, pageSize);
        }


        public async Task<PagedResult<CaregiverProfileUnverifiedDto>> GetUnverifiedCaregiverProfilesAsync(int pageNumber, int pageSize)
        {
            var query = _caregiverRepository.GetCaregiverProfiles(null, null, ascending: true);

            var totalCount = await query.CountAsync();
            var caregivers = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new CaregiverProfileUnverifiedDto
                    {
                        AboutMe = c.AboutMe,
                        CertificateOfNonConviction = c.CertificateOfNonConviction,
                        PassportCopy = c.PassportCopy,
                        ProfessionalCertificate = c.ProfessionalCertificate,
                        ProfessionalReferences = c.ProfessionalReferences,
                        Status = c.Status,
                        Services = c.Services.Select(s => new ServiceDto
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).ToList(),
                        DoB = c.DoB,
                        AverageRating = c.AverageRating,
                        City = c.City,
                        Gender = c.Gender,
                        HourlyRateUZS = c.HourlyRateUZS,
                        Latitude = c.Latitude,
                        Longitude = c.Longitude,
                        WorkPhoneNumber = c.WorkPhoneNumber,
                        Photo = c.Photo
                    })
                    .ToListAsync();

            return new PagedResult<CaregiverProfileUnverifiedDto>(caregivers, totalCount, pageNumber, pageSize);

        }

        public async Task<CaregiverProfileDto> GetCaregiverProfileInfoAsync(int id)
        {
            var caregiver = await _caregiverRepository.GetByIdAsync(id);

            var profile = new CaregiverProfileDto
            {
                AboutMe = caregiver.AboutMe,
                Age = DateTime.Now.Year - caregiver.DoB.Year,
                AverageRating = caregiver.AverageRating,
                City = caregiver.City,
                Services = caregiver.Services.Select(s => new ServiceDto
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList(),
                Gender = caregiver.Gender,
                HourlyRateUZS = caregiver.HourlyRateUZS,
                Latitude = caregiver.Latitude,
                Longitude = caregiver.Longitude,
                WorkPhoneNumber = caregiver.WorkPhoneNumber,
                Photo = caregiver.Photo,
                ProfessionalCertificate = caregiver.ProfessionalCertificate,
                ProfessionalReferences = caregiver.ProfessionalReferences
            };

            return profile;
        }
    }
}
