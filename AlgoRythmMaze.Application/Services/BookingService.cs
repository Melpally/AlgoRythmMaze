using AlgoRythmMaze.Application.Dtos;
using TopiTopi.Application.Interfaces;
using TopiTopi.Domain.Interfaces;

namespace TopiTopi.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly ICalendarService _calendarService;

        public BookingService(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public async Task CreateBookingAsync(BookingDto bookingDto)
        {
            // Here, you would save the booking to your database (via repository).

            // Sync booking with Google Calendar
            string calendarId = "primary"; // Replace with the caregiver's calendar ID
            string title = $"Booking for {bookingDto.ClientName} - {bookingDto.Service}";
            await _calendarService.CreateEventAsync(calendarId, title, bookingDto.StartTime, bookingDto.EndTime);
        }
    }
}
