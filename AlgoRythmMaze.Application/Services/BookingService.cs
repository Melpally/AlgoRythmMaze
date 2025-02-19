using AlgoRythmMaze.Application.Dtos;
using AlgoRythmMaze.Domain.Interfaces;
using AlgoRythmMaze.Domain.Models;
using TopiTopi.Application.Interfaces;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly ICalendarService _calendarService;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(ICalendarService calendarService, IBookingRepository bookingRepository)
        {
            _calendarService = calendarService;
            _bookingRepository = bookingRepository;
        }

        public async Task CreateBookingAsync(BookingDto dto)
        {
            var booking = new Booking
            {
                Notes = dto.Notes,
                CaregiverId = dto.CaregiverId,
                ServiceId = dto.ServiceId,
                ClientId = dto.ClientId,
                EndTime = dto.EndTime,
                StartTime = dto.StartTime
            };

            await _bookingRepository.CreateAsync(booking);


            string calendarId = dto.CaregiverEmail;
            string title = $"Booking for {dto.ClientName} - {dto.Service}";
            await _calendarService.CreateEventAsync(calendarId, title, dto.StartTime, dto.EndTime);
        }
    }
}
